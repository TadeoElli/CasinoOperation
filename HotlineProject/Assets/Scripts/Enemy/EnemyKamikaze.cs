using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikaze : EnemyController
{
    //public ParticleSystem explosion;
    public GameObject kamikaze;

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

    protected override void Attack() //kamikaze stats overrideadas
    {
        base.Attack();
        //Instantiate(explosion, transform.position, transform.rotation);
        //explosion.Emit(1);
        Debug.Log("Kamikaze exploded");
        Destroy(kamikaze, 0f);
        //...
    }
}
