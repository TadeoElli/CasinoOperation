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
        newPosition = _enemy.waypoints[_enemy.currentWaypoint];

        //Debug.Log(newPosition);
    }

    public void OnUpdate()
    {

        _enemy._view.Rotate(newPosition);
        agent.SetDestination(new Vector3(newPosition.x, newPosition.y, 0));
        Quaternion rotTarget = Quaternion.LookRotation(newPosition - _enemy.transform.position);
        _enemy.transform.rotation = Quaternion.RotateTowards(_enemy.transform.rotation, rotTarget, _enemy.rotationSpeed * Time.deltaTime);
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
