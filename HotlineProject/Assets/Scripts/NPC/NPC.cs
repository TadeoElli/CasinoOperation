using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent; 
    private UnityEngine.AI.NavMeshObstacle obstacle;
    private Vector3 originPosition, newPosition;
    [SerializeField] private Vector3[] waypoints;
    [SerializeField] public NPCView _view;
    private float timer1 = 0f;
    private float timer2 = 0f;
    private int currentWaypoint;
    [SerializeField] private float timeToReturn, moneyRadius, timeToPatrol;
    private bool isMoving, isReturning;
    [SerializeField] private bool hasPatrol, isWorker;

    //[SerializeField] public EnemyView _view;

    private void Awake() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateUpAxis = false;     //No tocar
        obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();

    }
    void Start()
    {  
        isMoving = false;
        isReturning = false;
        currentWaypoint = 0;
        originPosition = transform.position;
        obstacle.enabled = !obstacle.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(hasPatrol && !isMoving)
        {
            if(timer2 > timeToPatrol)
            {
                obstacle.enabled = false;
                agent.enabled = true;
                _view.Rotate(waypoints[currentWaypoint]);
                agent.SetDestination(new Vector3(waypoints[currentWaypoint].x, waypoints[currentWaypoint].y, transform.position.z));
                if(Vector3.Distance(transform.position, waypoints[currentWaypoint]) < 2f)
                {
                    timer2 = 0f;
                    currentWaypoint++;
                    if(currentWaypoint >= waypoints.Length)
                        currentWaypoint = 0;
                    agent.enabled = false;
                }
            }
            else
            {
                timer2 = timer2 + 1 * Time.deltaTime;
                obstacle.enabled = true;
            }
        }
    }

    private void FixedUpdate() {

        if(isMoving && !isReturning)
        {
            if(Vector3.Distance(transform.position, newPosition) < 2f)
            {
                if(timer1 > timeToReturn)
                {
                    isReturning = true;
                }
                else
                {
                    agent.enabled = false;
                    obstacle.enabled = true;
                    Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, moneyRadius);       //Agarra colliders dentro del radio

                    foreach (Collider2D hitCollider in colliderArray)   
                    {
                        if(hitCollider.TryGetComponent<Enemy>(out Enemy enemy)){   //Si ese collider pertenece a un objeto con la clase enemigo(se puede cambiar desp es un ej)
                                enemy.SearchNPC(transform.position);
                            }
                    }
                    timer1 = timer1 + 1 * Time.deltaTime;
                }
            }
        }
        else if(isMoving && isReturning)
        {
            obstacle.enabled = false;
            agent.enabled = true;
            agent.SetDestination(originPosition);
            _view.Rotate(originPosition);
            if(Vector3.Distance(transform.position, agent.destination) < 2f)
            {
                isMoving = false;
                isReturning = false;
                agent.enabled = false;
                obstacle.enabled = true;
            }
        }

        if(!agent.hasPath)
        {
            _view.StopAnim();
        }
        else
        {
            _view.PlayAnim();
        }
    }

    public void SearchMoney(Vector3 direction)
    {
        if(!isWorker)
        {
            newPosition = direction;
            obstacle.enabled = false;
            agent.enabled = true;
            agent.SetDestination(new Vector3(newPosition.x, newPosition.y, transform.position.z));
            _view.Rotate(newPosition);
            isMoving = true;
            timer1 = 0f;
        }
    }


    private void OnDrawGizmos()
    {  

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, moneyRadius);
    }
}
