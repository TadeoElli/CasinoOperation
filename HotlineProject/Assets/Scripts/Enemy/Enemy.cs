using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyBehavior
{
    Shooter,
    Melee,
    Kamikaze
}
public class Enemy : MonoBehaviour
{

    FSM<EnemyStates> _FSM;
    [SerializeField] private EnemyBehavior enemyType;
    public NavMeshAgent agent; 

    [SerializeField] public EnemyView _view;

    [Header ("Patrol")]
    public float timeToPatrol;
    public float patrolMaxRadius;
    public float patrolMinRadius;
    [Header("FOV")]
    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private float _viewRadius;
    [SerializeField] private float _viewAngle;
    [SerializeField] private LayerMask objectLayer;
    void Awake()
    {
        _FSM = new FSM<EnemyStates>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;     //No tocar

        IState idle = new EnemyIdleState(_FSM, this);
        _FSM.AddState(EnemyStates.Idle, new EnemyIdleState(_FSM, this));
        _FSM.AddState(EnemyStates.Patrol, new EnemyPatrolState(_FSM, this));

        switch(enemyType)
        {
            case EnemyBehavior.Shooter:
                _FSM.AddState(EnemyStates.Attack, new EnemyShooterState(_FSM, this));
                break;
            case EnemyBehavior.Kamikaze:
                _FSM.AddState(EnemyStates.Attack, new EnemyKamikazeState(_FSM, this));
                break;
            case EnemyBehavior.Melee:
                _FSM.AddState(EnemyStates.Attack, new EnemyMeleeState(_FSM, this));
                break;
            default:
                break;
        }
        _FSM.ChangeState(EnemyStates.Idle);
    }

    private void Start() {
        fieldOfView.SetValues(_viewRadius, _viewAngle, objectLayer);     //Inicializo los valores del fov
    }

    private void Update() {
        _FSM.Update();
        _FSM.FixedUpdate();
        CheckEnemiesInRange();
        fieldOfView.SetAimDirection(transform.forward);     //Funcion para q apunte a donde queremos(tiene q ser update)
        fieldOfView.SetOrigin(transform.position);      //Funcion para q empieze desde donde estamos(tiene q ser update)
    }


    public bool CheckEnemiesInRange()      //chequea que haya un enemigo en rango para que ataque automaticamente a melee
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, _viewRadius);       //Agarra colliders dentro del radio

        if(colliderArray != null)
        {
            foreach (Collider2D hitCollider in colliderArray)   
            {
                if(hitCollider.TryGetComponent<Player>(out Player player)){   //Si ese collider pertenece a un objeto con la clase enemigo(se puede cambiar desp es un ej)
                    if(InFieldOfView(player.transform.position))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        else
            return false;
    }

    
    private bool InFieldOfView(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;

        //Que este dentro de la distancia maxima de vision
        if (dir.sqrMagnitude > _viewRadius * _viewRadius) return false;

    
        //Que este dentro del angulo
        return Vector3.Angle(transform.forward, dir) <= _viewAngle/2;
    }


    private void OnDrawGizmos()
    {  
        ///FOV Gizmos
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, patrolMaxRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, patrolMinRadius);
    }
}
