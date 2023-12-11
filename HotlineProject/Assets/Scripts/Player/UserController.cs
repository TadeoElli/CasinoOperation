using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController     //Esta clase va a manejar todos los inputs del jugador
    {
        PlayerModel _model;
        PlayerView _view;
        GameDataController _dataController;
        MovementJoystick _movementJoystick;

        public Vector3 targetPosition;

        public UserController(PlayerModel model, PlayerView view, GameDataController dataController, MovementJoystick movementJoystick)
        {
            _model = model;
            _view = view;
            _dataController = dataController;
            targetPosition = _model._player.transform.position;
            _movementJoystick = movementJoystick;
            
        }

        
        public void ListenKeys()        //Pregunto si se toco en alguna parte del mapa
        {
            if(_dataController.navMesh)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            else
            {
                if(_movementJoystick != null)
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        //_joystickController._initialPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        //targetPosition = _joystickController.GetMovementInput();
                    }
                    targetPosition = _movementJoystick.joystickVec;
                }
            }
        }

        public void ListenFixedKeys()       //Paso la posicion para moverse y rotar
        {
            if(_dataController.navMesh)
            {
                _model.MovementNavMesh(targetPosition);      
                _view.Rotate(targetPosition);
                if(!_model._player.agent.hasPath)
                {
                    _view.StopAnim();
                }
                else
                {
                    _view.PlayAnim();
                }
            }
            else
            {
                _model.MovementJoystick(targetPosition);
                _view.Rotate(_view.transform.position + targetPosition);
                if(targetPosition != Vector3.zero)
                {
                    _view.PlayAnim();
                }
                else
                {
                    _view.StopAnim();
                }
            }
        }


    }
