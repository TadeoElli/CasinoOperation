using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePointer : MonoBehaviour
{
    // Start is called before the first frame update
    private Player _player;
    [SerializeField] private GameObject objective;
    [SerializeField] private float rotationModifier, rotationSpeed;

    private void Awake() {
        _player = FindObjectOfType<Player>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(objective == null)
        {
            Destroy(this.gameObject);
        }
        this.transform.position = _player.transform.position;
        Rotate(objective.transform.position);
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
