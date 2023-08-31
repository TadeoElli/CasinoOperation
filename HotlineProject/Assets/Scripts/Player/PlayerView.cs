using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{

    Player _player;
    private void Awake() {
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()       // Para que el sprite este siempre sobre el player
    {
        this.transform.position = _player.transform.position;
    }

    public void Rotate(Vector3 target)      //Roto hacia la direccion donde se esta moviendo
    {
        float angleRad = Mathf.Atan2(target.y - this.transform.position.y, target.x - this.transform.position.x);
        float angleGrad = (180 / Mathf.PI) * angleRad + 90;
        this.transform.rotation = Quaternion.Euler(0,0, angleGrad);
    }
}
