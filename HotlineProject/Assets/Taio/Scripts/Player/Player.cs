using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D _myRb;       
    PlayerModel _model;
    UserController _controller;
    public float _currentMoveSpeed;     //Velocidad del jugador actual(Por si aplicamos potenciadores etc)

    [Header("FOV")]
    [SerializeField] private float _viewRadius;
    [SerializeField] private float _viewAngle;
    [SerializeField] private LayerMask enemyLayer;
    void Awake()
    {
        _model = new PlayerModel(this);     //Creo la clase playerModel y le mando esta clase como ref
        //PlayerView view = new PlayerView(this);       //Desp usaremos esta clase para manejar los aspectos visuales del jugador (feedback, animaciones)
        //_model.OnStartMoving += view.StartMoveAnimation;      //Y esto seria para sumar funciones asi cuando llamamos a la funcion de mover tamb al del respectivo feedback
        _controller = new UserController(_model);       //Creo la clase UserController y le mando esta clase como ref
    }

    // Update is called once per frame
    void Update()
    {
        _controller.ListenKeys();
    }

    private void FixedUpdate() 
    {
        _controller.ListenFixedKeys();
        //CheckEnemiesInRange();
    }
/*
    private void CheckEnemiesInRange()      //chequea que haya un enemigo en rango para que ataque automaticamente a melee
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, _viewRadius);       //Agarra colliders dentro del radio

        foreach (Collider2D hitCollider in colliderArray)   
        {
            if(hitCollider.TryGetComponent<Enemy>(out Enemy enemy)) {   //Si ese collider pertenece a un objeto con la clase enemigo(se puede cambiar desp es un ej)
                if(InFieldOfView(enemy.transform.position))
                {
                    Debug.Log("attack");
                }
            }
        }
    }

    Vector3 GetDirFromAngle(float angle)
    {
        return new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
    }
    
    public bool InFieldOfView(Vector2 targetPos)
    {
        Vector2 dir = new Vector2(targetPos.x - transform.position.x, targetPos.y - transform.position.y);

        //Que este dentro de la distancia maxima de vision
        if (dir.sqrMagnitude > _viewRadius * _viewRadius) return false;


        //Que este dentro del angulo
        return Vector2.Angle(transform.forward, dir) <= _viewAngle/2;
    }


    private void OnDrawGizmos()
    {  
        var realAngle = _viewAngle / 2;

        Gizmos.color = Color.magenta;
        Vector3 lineLeft = GetDirFromAngle(-realAngle + transform.eulerAngles.z);
        Gizmos.DrawLine(transform.position, transform.position + lineLeft * _viewRadius);

        Vector3 lineRight = GetDirFromAngle(realAngle + transform.eulerAngles.z);
        Gizmos.DrawLine(transform.position, transform.position + lineRight * _viewRadius);

    }
    */
}
