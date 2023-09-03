using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterState : IState
{
    // Start is called before the first frame update

    Enemy _enemy;

    FSM<EnemyStates> _fsm;


    public EnemyShooterState(FSM<EnemyStates> fsm, Enemy enemy)
    {
        _enemy = enemy;

        _fsm = fsm;


    }
    public void OnEnter()
    {
        Debug.Log("Shoot");
    }

    public void OnUpdate()
    {

    }

    public void OnFixedUpdate()
    {

    }

    public void OnExit()
    {
    }
}
