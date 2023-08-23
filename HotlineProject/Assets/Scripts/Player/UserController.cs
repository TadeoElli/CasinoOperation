using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController     //Esta clase va a manejar todos los inputs del jugador
    {
        PlayerModel _model;

        float _horizontalAxi, _verticalAxi;

        public UserController(PlayerModel model)
        {
            _model = model;
        }

        public void ListenKeys()        //Guardo los valores x e y
        {
            _horizontalAxi = Input.GetAxisRaw("Horizontal");

            _verticalAxi = Input.GetAxisRaw("Vertical");

        }

        public void ListenFixedKeys()
        {
            _model.Movement(_horizontalAxi, _verticalAxi);      //Se los mando a la clase modelo
        }

    }
