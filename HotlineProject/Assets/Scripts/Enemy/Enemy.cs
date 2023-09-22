using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyBehaviour
{
    Shooter,
    Melee,
    Kamikaze
}
public enum EnemyPatrol
{
    Random,
    Waypoints
}
public class Enemy : MonoBehaviour
{

    FSM<EnemyStates> _FSM;
    [SerializeField] private EnemyBehaviour enemyType;
    [SerializeField] private EnemyPatrol enemyPatrol;
    public NavMeshAgent agent; 

    [SerializeField] public EnemyView _view;
    public float rotationSpeed, timeToReturn, attackRadius;
    [HideInInspector] public Vector3 newPosition;
    [HideInInspector] public Transform playerPosition;

    [Header ("Patrol")]
    public float timeToPatrol;
    public Vector3[] waypoints;
    public Vector3 originPosition;
    public int currentWaypoint;
    public float patrolMaxRadius;
    public float patrolMinRadius;

    [Header("FOV")]
    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] public float _minViewRadius;
    [SerializeField] public float _maxViewRadius;
    [SerializeField] private float _viewAngle;
    [SerializeField] private LayerMask objectLayer;

    [SerializeField] public Collider2D enemyCollider; //Cambiar de lugar esta refe, es temporal

    void Awake()
    {
        _FSM = new FSM<EnemyStates>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;     //No tocar

        IState idle = new EnemyIdleState(_FSM, this);
        _FSM.AddState(EnemyStates.Idle, new EnemyIdleState(_FSM, this));
        _FSM.AddState(EnemyStates.Search, new EnemySearchState(_FSM, this));
        switch(enemyPatrol)
        {
            case EnemyPatrol.Random:
                _FSM.AddState(EnemyStates.Patrol, new EnemyPatrolRandomState(_FSM, this));
                _FSM.AddState(EnemyStates.Return, new EnemyReturnState(_FSM, this));
                break;
            case EnemyPatrol.Waypoints:
                _FSM.AddState(EnemyStates.Patrol, new EnemyPatrolWaypointsState(_FSM, this));
                break;
            default:
                break;
        }

        switch(enemyType)
        {
            case EnemyBehaviour.Shooter:
                _FSM.AddState(EnemyStates.Attack, new EnemyShooterState(_FSM, this));
                break;
            case EnemyBehaviour.Kamikaze:
                _FSM.AddState(EnemyStates.Attack, new EnemyKamikazeState(_FSM, this));
                break;
            case EnemyBehaviour.Melee:
                _FSM.AddState(EnemyStates.Attack, new EnemyMeleeState(_FSM, this));
                break;
            default:
                break;
        }
        _FSM.ChangeState(EnemyStates.Idle);
    }

    private void Start() {
        fieldOfView.SetValues(_minViewRadius, _viewAngle, objectLayer);     //Inicializo los valores del fov
        currentWaypoint = 0;
        originPosition = this.transform.position;
    }

    private void Update() {
        _FSM.Update();
    
           
        fieldOfView.SetAimDirection(transform.forward);     //Funcion para q apunte a donde queremos(tiene q ser update)
        fieldOfView.SetOrigin(transform.position);      //Funcion para q empieze desde donde estamos(tiene q ser update)
    }
    private void FixedUpdate() {
        _FSM.FixedUpdate();
        if (CheckEnemiesInRange())
        {
            _FSM.ChangeState(EnemyStates.Attack);
        }
    }
    public void SearchNPC(Vector3 direction)
    {
        newPosition = direction;
        _FSM.ChangeState(EnemyStates.Search);
    }
    public bool CheckEnemiesInRange()      //chequea que haya un enemigo en rango para que ataque automaticamente a melee
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, _minViewRadius);       //Agarra colliders dentro del radio

        if(colliderArray != null)
        {
            foreach (Collider2D hitCollider in colliderArray)   
            {
                if(hitCollider.TryGetComponent<Player>(out Player player)){   //Si ese collider pertenece a un objeto con la clase enemigo(se puede cambiar desp es un ej)
                    if(InFieldOfView(player.transform.position))
                    {
                        playerPosition = player.transform;
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
        if (dir.sqrMagnitude > _minViewRadius * _minViewRadius) return false;

        if (InLineOfSight(dir, _minViewRadius)) return false;
    
        //Que este dentro del angulo
        return Vector3.Angle(transform.forward, dir) <= _viewAngle/2;
    }
    public bool InLineOfSight(Vector3 direction, float radius)
    {
        //RaycastHit hit;
        return Physics2D.Raycast(transform.position, direction, radius, objectLayer);
        //return Physics.SphereCast(transform.position,1.5f, direction, out hit, direction.magnitude, objectLayer);
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
