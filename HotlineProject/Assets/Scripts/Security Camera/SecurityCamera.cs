using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float rotationModifier, rotationSpeed;
    public Vector3 destination;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToTarget = destination - transform.position;
        vectorToTarget.z = 0;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }

    public void Rotate(Vector3 target)      //Roto hacia la direccion donde se esta moviendo
    {
        destination = target;
    }
}
