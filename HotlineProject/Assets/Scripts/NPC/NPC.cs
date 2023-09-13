using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent; 
    private Vector3 originPosition;
    [SerializeField] public NPCView _view;
    private float timer = 0f;
    [SerializeField] private float timeToReturn, moneyRadius;
    private bool isMoving;

    //[SerializeField] public EnemyView _view;

    private void Awake() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateUpAxis = false;     //No tocar

    }
    void Start()
    {  
        isMoving = false;
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            if(Vector3.Distance(transform.position, agent.destination) < 2f)
            {
                if(timer > timeToReturn)
                {
                    agent.SetDestination(originPosition);
                    _view.Rotate(originPosition);
                    isMoving = false;

                    
                    
                }
                else
                {
                    Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, moneyRadius);       //Agarra colliders dentro del radio

                    foreach (Collider2D hitCollider in colliderArray)   
                    {
                        if(hitCollider.TryGetComponent<Enemy>(out Enemy enemy)){   //Si ese collider pertenece a un objeto con la clase enemigo(se puede cambiar desp es un ej)
                                enemy.SearchNPC(transform.position);
                            }
                    }
                    timer = timer + 1 * Time.deltaTime;
                }
            }
        }
    }

    private void FixedUpdate() {

    }

    public void SearchMoney(Vector3 direction)
    {
        agent.SetDestination(new Vector3(direction.x, direction.y, transform.position.z));
        _view.Rotate(direction);
        isMoving = true;
        timer = 0f;
    }

    private void OnDrawGizmos()
    {  

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, moneyRadius);
    }
}
