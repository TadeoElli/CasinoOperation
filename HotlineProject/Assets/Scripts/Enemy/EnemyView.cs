using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{

    [SerializeField] private Enemy _enemy;
    [SerializeField] private float rotationModifier, rotationSpeed;
    private void Awake() {

    }

    // Update is called once per frame
    void Update()       // Para que el sprite este siempre sobre el player
    {
        this.transform.position = _enemy.transform.position;
    }

    public void Rotate(Vector3 target)      //Roto hacia la direccion donde se esta moviendo
    {
        /*float angleRad = Mathf.Atan2(target.y - this.transform.position.y, target.x - this.transform.position.x);
        float angleGrad = (180 / Mathf.PI) * angleRad + 90;
        this.transform.rotation = Quaternion.Euler(0,0, angleGrad);
        */
        Vector3 vectorToTarget = target - transform.position;
        vectorToTarget.z = _enemy.transform.position.z;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }
}
