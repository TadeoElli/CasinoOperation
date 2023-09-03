using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikazeState : IState
{
    // Start is called before the first frame update

    Enemy _enemy;

    FSM<EnemyStates> _fsm;


    public EnemyKamikazeState(FSM<EnemyStates> fsm, Enemy enemy)
    {
        _enemy = enemy;

        _fsm = fsm;


    }
    public void OnEnter()
    {
        Debug.Log("Kamikaze");
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
