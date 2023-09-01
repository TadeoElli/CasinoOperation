using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyController
{
    public GameObject bullet;
    public float shootingRange;

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

    protected override void Attack() //ataque de shooter
    {
        base.Attack();
        if (Vector3.Distance(transform.position, playerPos.transform.position) <= shootingRange)
        {
            Debug.Log("Shooting...");
        }
        //...
    }
}

