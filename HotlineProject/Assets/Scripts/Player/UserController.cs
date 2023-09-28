using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController     //Esta clase va a manejar todos los inputs del jugador
    {
        PlayerModel _model;
        PlayerView _view;

        public Vector3 targetPosition;

        public UserController(PlayerModel model, PlayerView view)
        {
            _model = model;
            _view = view;
            targetPosition = _model._player.transform.position;
        }

        public void ListenKeys()        //Pregunto si se toco en alguna parte del mapa
        {
            if(Input.GetMouseButtonDown(0))
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                MoneyAbility();
            }
        }

        public void ListenFixedKeys()       //Paso la posicion para moverse y rotar
        {
            _model.Movement(targetPosition);      
            _view.Rotate(targetPosition);
        }

        private void MoneyAbility()
        {
            _model.ThrowMoney();
            var newMoney = MoneyFactory.Instance.GetObject();

            //Seteamos la posicion
            newMoney.transform.position = _model._player.transform.position;
            
            
        }

    }
