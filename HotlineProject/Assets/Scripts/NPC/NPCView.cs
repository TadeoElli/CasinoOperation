using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCView : MonoBehaviour
{

    [SerializeField] private NPC _npc;
    [SerializeField] private float rotationModifier, rotationSpeed;
    private Vector3 destination;
    private bool searching = false;
    private Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()       // Para que el sprite este siempre sobre el player
    {
        this.transform.position = _npc.transform.position;
        if(searching)
        {
            if(Vector3.Distance(transform.position, destination) < 1)
                searching = false;
            else
            {
                Vector3 vectorToTarget = destination - transform.position;
                vectorToTarget.z = _npc.transform.position.z;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
            }
            
        }
    }

    public void Rotate(Vector3 target)      //Roto hacia la direccion donde se esta moviendo
    {
        destination = target;
        searching = true;
    }

    public void PlayAnim()
    {
        animator.SetBool("IsMoving", true);
    }

    public void StopAnim()
    {
        animator.SetBool("IsMoving", false);
    }
}
