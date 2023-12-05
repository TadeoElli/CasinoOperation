using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchState : IState
{

    Enemy _enemy;
    UnityEngine.AI.NavMeshAgent agent;
    FSM<EnemyStates> _fsm;
    Vector3 newPosition;
    float timer;


    public EnemySearchState(FSM<EnemyStates> fsm, Enemy enemy)
    {
        _enemy = enemy;

        _fsm = fsm;
        agent = _enemy.agent;

    }
    public void OnEnter()
    {
        newPosition = newPosition + new Vector3(Random.Range(-5,5),Random.Range(-5,5),0);
        newPosition = _enemy.newPosition;
        timer = 0f;
        _enemy.fieldOfView.ChangeSearchMaterial();
    }

    public void OnUpdate()
    {
        _enemy._view.Rotate(newPosition);
        agent.SetDestination(new Vector3(newPosition.x, newPosition.y, _enemy.transform.position.z));
        Quaternion rotTarget = Quaternion.LookRotation(newPosition - _enemy.transform.position);
        _enemy.transform.rotation = Quaternion.RotateTowards(_enemy.transform.rotation, rotTarget, _enemy.rotationSpeed * Time.deltaTime);
    }

    public void OnFixedUpdate()
    {

        if(timer > _enemy.timeToReturn)
        {
            _fsm.ChangeState(EnemyStates.Idle);
        }
        else
        {
            if(_enemy.CheckEnemiesInRange())
                _fsm.ChangeState(EnemyStates.Attack);
            else
            {
                timer = timer + 1 * Time.deltaTime;
            }
        }
        

    }

    public void OnExit()
    {
        _enemy.fieldOfView.RestoreMaterial();
    }

}
