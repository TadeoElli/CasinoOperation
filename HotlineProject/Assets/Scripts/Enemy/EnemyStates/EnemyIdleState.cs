using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IState
{
    // Start is called before the first frame update

    Enemy _enemy;

    FSM<EnemyStates> _fsm;

    float timer;

    public EnemyIdleState(FSM<EnemyStates> fsm, Enemy enemy)
    {
        _enemy = enemy;

        _fsm = fsm;


    }
    public void OnEnter()
    {
        timer = 0;
    }

    public void OnUpdate()
    {
        if(timer >= _enemy.timeToPatrol)
        {
            _fsm.ChangeState(EnemyStates.Patrol);
        }
        else
            timer = timer + 1 * Time.deltaTime;
    }

    public void OnFixedUpdate()
    {
        if(_enemy.CheckEnemiesInRange())
            _fsm.ChangeState(EnemyStates.Attack);
    }

    public void OnExit()
    {
    }
}
