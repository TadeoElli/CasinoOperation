using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    protected int life;
    protected int damage;
    private float attackRange;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform playerPos;

    [Header("Movement")]
    public float detectionRange = 10f; // Rango de detección del jugador
    public float chaseSpeed = 5f; // Velocidad de persecución
    public float patrolRadius = 5f; // Radio de la patrulla

    private Vector3 currentPatrolTarget;
    private bool patrolling;
    

    private void Start()
    {
        currentPatrolTarget = GetRandomPatrolPosition();
    }

    private void Update()
    {
        if (IsPlayerInRange())
        {
            patrolling = false;
            EnemyMovement();
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

    private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, playerPos.position) <= detectionRange;
    }

    private Vector3 GetRandomPatrolPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * patrolRadius;
        return transform.position + new Vector3(randomCircle.x, randomCircle.y, 0f);
    }

    private void Patrol()
    {

        if (Vector3.Distance(transform.position, currentPatrolTarget) <= 0.2f)
        {
            currentPatrolTarget = GetRandomPatrolPosition();
        }

        Vector3 direction = (currentPatrolTarget - transform.position).normalized;
        Vector3 velocity = direction * chaseSpeed * Time.deltaTime;
        transform.right = direction;
        rb.MovePosition(transform.position + velocity);
    }

    private void EnemyMovement()
    {
        Vector3 direction = (playerPos.position - transform.position).normalized;
        Vector3 velocity = direction * chaseSpeed * Time.deltaTime;
        transform.right = direction;
        rb.MovePosition(transform.position + velocity);
    }

    private void Attack()
    {
        if (Vector3.Distance(transform.position, playerPos.transform.position) <= attackRange)
        {

        }
    }

    private void TakeDamage(int damage)
    {
        
    }
}
