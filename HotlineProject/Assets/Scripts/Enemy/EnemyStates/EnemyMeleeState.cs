using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeState : IState
{

    Enemy _enemy;
    UnityEngine.AI.NavMeshAgent agent;
    FSM<EnemyStates> _fsm;


    public EnemyMeleeState(FSM<EnemyStates> fsm, Enemy enemy)
    {
        _enemy = enemy;

        _fsm = fsm;
        agent = _enemy.agent;

    }
    public void OnEnter()
    {
        //_enemy.enemyCollider.gameObject.SetActive(true);
        _enemy.fieldOfView.ChangeAlertMaterial();
        _enemy.isAlert = true;
    }

    public void OnUpdate()
    {
        if(Vector3.Distance(_enemy.transform.position, _enemy.playerPosition.position) < _enemy._minViewRadius)
        {
            Move();
        }
        else
        {
            Vector3 dir = _enemy.playerPosition.position - _enemy.transform.position; 
            if(Vector3.Distance(_enemy.transform.position, _enemy.playerPosition.position) < _enemy._maxViewRadius && !_enemy.InLineOfSight(dir, _enemy._maxViewRadius))
            {
                Move();
            }
            else
            {
                _fsm.ChangeState(EnemyStates.Idle);
            }
        }
    }

    public void OnFixedUpdate()
    {
        if(Vector3.Distance(_enemy.transform.position, _enemy.playerPosition.position) < _enemy.attackRadius)
        {
            Debug.Log("melee");
        }
    }

    public void OnExit()
    {
        _enemy.fieldOfView.RestoreMaterial();
        _enemy.isAlert = false;
    }

    private void Move()
    {
        _enemy._view.Rotate(_enemy.playerPosition.position);
        agent.SetDestination(new Vector3(_enemy.playerPosition.position.x, _enemy.playerPosition.position.y, _enemy.transform.position.z));
        Quaternion rotTarget = Quaternion.LookRotation(_enemy.playerPosition.position - _enemy.transform.position);
        _enemy.transform.rotation = Quaternion.RotateTowards(_enemy.transform.rotation, rotTarget, _enemy.rotationSpeed * Time.deltaTime);
    }
}
