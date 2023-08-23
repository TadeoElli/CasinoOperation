using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel        //Esta clase va a manejar el gameObject jugador (moverlo, destruirlo si muere etc)
{

    //Movement
    [HideInInspector]
    public Vector2 _moveDir;    //Vector de direccion
    [HideInInspector]
    float moveX, moveY;         //Valores de x e y

    //public event Action<float> OnStartMoving = delegate { };      Para usar desp

    //References
    Rigidbody2D _myRb;
    Player _player;


    public PlayerModel(Player _user)        //Desde Player creo la clase playerModel y le paso el rigidbody y la clase player como ref
    {
        _player = _user;
        _myRb = _player._myRb;
        
    }

    public void Movement(float horizontal, float vertical)      //Recivo los valores x e y y creo un vector q se va a multiplicar por la velocidad del rgbd
    {
        moveX = horizontal;
        moveY = vertical;

        _moveDir = new Vector2(moveX, moveY).normalized;

        _myRb.velocity = new Vector2(_moveDir.x * _player._currentMoveSpeed, _moveDir.y * _player._currentMoveSpeed);

        //OnStartMoving(_moveDir.sqrMagnitude);     Para usar desp
    }

}
