using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeState : IState
{

    Enemy _enemy;

    FSM<EnemyStates> _fsm;


    public EnemyMeleeState(FSM<EnemyStates> fsm, Enemy enemy)
    {
        _enemy = enemy;

        _fsm = fsm;


    }
    public void OnEnter()
    {
        _enemy.enemyCollider.gameObject.SetActive(true);
        Debug.Log("melee");
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
