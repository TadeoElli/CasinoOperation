using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    protected int life;
    protected int damage;
    public float attackRange;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] protected Transform playerPos;

    [Header("Movement")]
    public float detectionRange = 10f;
    public float chaseSpeed = 5f;
    public float patrolRadius = 5f;

    protected Vector3 currentPatrolTarget;
    protected bool patrolling;
    

    private void Start()
    {
        currentPatrolTarget = GetRandomPatrolPosition();
    }

    protected bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, playerPos.position) <= detectionRange;
    }

    protected Vector3 GetRandomPatrolPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * patrolRadius;
        return transform.position + new Vector3(randomCircle.x, randomCircle.y, 0f);
    }

    protected void Patrol()
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

    protected void EnemyMovement()
    {
        Vector3 direction = (playerPos.position - transform.position).normalized;
        Vector3 velocity = direction * chaseSpeed * Time.deltaTime;
        transform.right = direction;
        rb.MovePosition(transform.position + velocity);
    }

    protected virtual void Attack() { }

    protected void TakeDamage(int damage)
    {
        life -= damage;
        if (life >= 0)
        {
            Destroy(this, 0f);
        }
    }
}
