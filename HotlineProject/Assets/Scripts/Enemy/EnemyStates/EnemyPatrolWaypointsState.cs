using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolWaypointsState : IState
{

    Enemy _enemy;
    UnityEngine.AI.NavMeshAgent agent;
    FSM<EnemyStates> _fsm;
    Vector3 newPosition;



    public EnemyPatrolWaypointsState(FSM<EnemyStates> fsm, Enemy enemy)
    {
        _enemy = enemy;

        _fsm = fsm;
        agent = _enemy.agent;

    }
    public void OnEnter()
    {
        newPosition = _enemy.waypoints[_enemy.currentWaypoint].transform.position;

        Debug.Log(newPosition);
    }

    public void OnUpdate()
    {

        _enemy._view.Rotate(newPosition);
        agent.SetDestination(new Vector3(newPosition.x, newPosition.y, _enemy.transform.position.z));
        _enemy.transform.forward = new Vector3(newPosition.x - _enemy.transform.position.x, newPosition.y - _enemy.transform.position.y, _enemy.transform.position.z);

    }

    public void OnFixedUpdate()
    {
        if(Vector2.Distance(_enemy.transform.position, newPosition) < 1)
        {
            _fsm.ChangeState(EnemyStates.Idle);
        }
        else
        {
            if(_enemy.CheckEnemiesInRange())
                _fsm.ChangeState(EnemyStates.Attack);
        }
    }

    public void OnExit()
    {
        _enemy.currentWaypoint++;
        if(_enemy.currentWaypoint >= _enemy.waypoints.Length)
            _enemy.currentWaypoint = 0;
    }

}
