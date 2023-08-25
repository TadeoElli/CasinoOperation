using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    Transform cameraFollow;
    [SerializeField] private Vector3 offset;
    void Awake()
    {
        cameraFollow = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = cameraFollow.position + offset;
    }
}
