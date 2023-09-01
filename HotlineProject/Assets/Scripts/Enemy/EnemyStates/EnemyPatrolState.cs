using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : IState
{

    Enemy _enemy;
    UnityEngine.AI.NavMeshAgent agent;
    FSM<EnemyStates> _fsm;
    Vector3 newPosition;
    bool isPatrolling;


    public EnemyPatrolState(FSM<EnemyStates> fsm, Enemy enemy)
    {
        _enemy = enemy;

        _fsm = fsm;
        agent = _enemy.agent;

    }
    public void OnEnter()
    {
        newPosition = NewPosition();
        isPatrolling = false;
        //Debug.Log(newPosition);
    
    }

    public void OnUpdate()
    {
        if(Vector2.Distance(_enemy.transform.position, newPosition) < _enemy.patrolMinRadius && !isPatrolling)
        {
            newPosition = NewPosition();
            //Debug.Log(newPosition);
        }
        else if(newPosition.x < -16f || newPosition.x > 18f || newPosition.y < -25f || newPosition.y > 45f)
        {
            newPosition = NewPosition();
        }
        else
        {
            isPatrolling = true;
            agent.SetDestination(new Vector3(newPosition.x, newPosition.y, _enemy.transform.position.z));
            _enemy.transform.forward = new Vector3(newPosition.x - _enemy.transform.position.x, newPosition.y - _enemy.transform.position.y, _enemy.transform.position.z);
        }
    }

    public void OnFixedUpdate()
    {
        if(Vector2.Distance(_enemy.transform.position, agent.destination) < 1 && isPatrolling)
        {
            _fsm.ChangeState(EnemyStates.Idle);
            
        }
    }

    public void OnExit()
    {

    }

    private Vector3 NewPosition()
    {
        return new Vector3(Random.Range(_enemy.transform.position.x - _enemy.patrolMaxRadius, _enemy.transform.position.x + _enemy.patrolMaxRadius), Random.Range(_enemy.transform.position.y - _enemy.patrolMaxRadius, _enemy.transform.position.y + _enemy.patrolMaxRadius), _enemy.transform.position.z);
    }
}
