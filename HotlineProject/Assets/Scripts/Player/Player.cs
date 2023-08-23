using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D _myRb;       
    PlayerModel _model;
    UserController _controller;
    public float _currentMoveSpeed;     //Velocidad del jugador actual(Por si aplicamos potenciadores etc)
    void Awake()
    {
        _model = new PlayerModel(this);     //Creo la clase playerModel y le mando esta clase como ref
        //PlayerView view = new PlayerView(this);       //Desp usaremos esta clase para manejar los aspectos visuales del jugador (feedback, animaciones)
        //_model.OnStartMoving += view.StartMoveAnimation;      //Y esto seria para sumar funciones asi cuando llamamos a la funcion de mover tamb al del respectivo feedback
        _controller = new UserController(_model);       //Creo la clase UserController y le mando esta clase como ref
    }

    // Update is called once per frame
    void Update()
    {
        _controller.ListenKeys();
    }

     private void FixedUpdate() 
    {
        _controller.ListenFixedKeys();
    }
}
