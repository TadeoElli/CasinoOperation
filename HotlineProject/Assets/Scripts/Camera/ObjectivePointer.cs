using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePointer : MonoBehaviour
{
    // Start is called before the first frame update
    private Player _player;
    public float minDistance;
    private Transform target;
    [SerializeField] public List<GameObject> cardObjective;
    [SerializeField] private GameObject midGoal, finishGoal;
    [SerializeField] private float rotationModifier, rotationSpeed;

    private void Awake() {
        _player = FindObjectOfType<Player>();
    }
    void Start()
    {
        minDistance = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.cardsInLevel > 0)
        {
            
            foreach (var objective in cardObjective)
            {
                if(objective != null)
                {
                    if(Vector3.Distance(_player.transform.position, objective.transform.position) < minDistance)
                    {
                        target = objective.transform;
                    }
                    this.transform.position = _player.transform.position;
                    minDistance = Vector3.Distance(_player.transform.position, target.position);
                    Rotate(target.position);
                }
                /*else
                {
                    cardObjective.Remove(objective);
                    minDistance = 200f;
                }
                */
            }
            
        }
        else
        {
            if(midGoal != null)
            {
                this.transform.position = _player.transform.position;
                Rotate(midGoal.transform.position);
            }
            else
            {
                this.transform.position = _player.transform.position;
                Rotate(finishGoal.transform.position);
            }
        }
        
        
    }

    private void Rotate(Vector3 target)
    {
        Vector3 vectorToTarget = target - transform.position;
        vectorToTarget.z = transform.position.z;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }
}
