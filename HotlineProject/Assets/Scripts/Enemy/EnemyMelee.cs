using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyController
{   
    void Update()
    {
        if (IsPlayerInRange())
        {
            patrolling = false;
            EnemyMovement();

            if (Vector3.Distance(transform.position, playerPos.transform.position) <= attackRange)
            {
                Attack();
            }
        }
        else
        {
            if (!patrolling)
            {
                patrolling = true;
                currentPatrolTarget = GetRandomPatrolPosition();
            }
            Patrol();
        }
    }

    protected override void Attack() //ataque melee
    {
        base.Attack();
        Debug.Log("Enemy Melee Attack");
        //...
    }
}
