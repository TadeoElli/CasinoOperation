using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Ref")]
    public Rigidbody2D _myRb; 
    public NavMeshAgent agent;      
    public PlayerModel _model;
    [SerializeField] private PlayerView _view;
    public UserController  _controller;

    [Header("FOV")]
    [SerializeField] private float _viewRadius;
    [SerializeField] private float _viewAngle;

    //[SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private LayerMask objectLayer;
    [SerializeField] public GameDataController gameDataController;
    [SerializeField] private MovementJoystick movementJoystick;

    

    [Header("Hability")]
    [SerializeField] public float moneyRadius;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        gameDataController = FindObjectOfType<GameDataController>();
        movementJoystick = FindObjectOfType<MovementJoystick>();
        _model = new PlayerModel(this);     //Creo la clase playerModel y le mando esta clase como ref
        _controller = new UserController(_model, _view, gameDataController, movementJoystick);       //Creo la clase UserController y le mando el model y el view
        
        agent.updateUpAxis = false;     //No tocar
    }
    private void Start() {
        //fieldOfView.SetValues(_viewRadius, _viewAngle, objectLayer);     //Inicializo los valores del fov
    }
    // Update is called once per frame
    void Update()
    {
        _controller.ListenKeys();
        //fieldOfView.SetAimDirection(transform.forward);     //Funcion para q apunte a donde queremos(tiene q ser update)
        //fieldOfView.SetOrigin(transform.position);      //Funcion para q empieze desde donde estamos(tiene q ser update)
    }

    private void FixedUpdate() 
    {
        _controller.ListenFixedKeys();
        CheckEnemiesInRange();
    }


    private void CheckEnemiesInRange()      //chequea que haya un enemigo en rango para que ataque automaticamente a melee
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, _viewRadius);       //Agarra colliders dentro del radio

        foreach (Collider2D hitCollider in colliderArray)   
        {
            if(hitCollider.gameObject.tag == "Enemy") {   //Si ese collider pertenece a un objeto con la clase enemigo(se puede cambiar desp es un ej)
                if(InFieldOfView(hitCollider.transform.position))
                {
                    Debug.Log("attack");
                }
            }
        }
    }

    Vector3 GetDirFromAngle(float angle)
    {
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),Mathf.Cos(angle * Mathf.Deg2Rad), 0);
    }
    
    public bool InFieldOfView(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;

        //Que este dentro de la distancia maxima de vision
        if (dir.sqrMagnitude > _viewRadius * _viewRadius) return false;

    
        //Que este dentro del angulo
        return Vector3.Angle(transform.forward, dir) <= _viewAngle/2;
    }

    private void OnDrawGizmos()
    {  
        var realAngle = _viewAngle / 2;

        Gizmos.color = Color.magenta;
        Vector3 lineLeft = GetDirFromAngle(-realAngle + transform.eulerAngles.z);
        Gizmos.DrawLine(transform.position, transform.position + lineLeft * _viewRadius);

        Vector3 lineRight = GetDirFromAngle(realAngle + transform.eulerAngles.z);
        Gizmos.DrawLine(transform.position, transform.position + lineRight * _viewRadius);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, moneyRadius);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            GameManager.Instance.EndLevel();
        }
    }
}
