using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private Vector3 startPos;
    private float speed = 4;
    private GameObject player;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private HealthController healthController;
    private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthController = GetComponent<HealthController>();
        player = GameObject.Find("Player");
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }

        float distance = (player.transform.position - transform.position).magnitude;
        movement = new Vector2(0, 0);
        if (distance > 1.5f)
        { 
            movement = (player.transform.position - transform.position).normalized;
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }

        TriggerAnimmations();
    }

    private void TriggerAnimmations()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (movement.sqrMagnitude > 0.01f)
        {
            animator.SetFloat("HorizontalBeforeIdle", movement.x);
            animator.SetFloat("VerticalBeforeIdle", movement.y);
        }
    }

    private Vector3 GetRoamingPosition()
    {
        float randomDistance = Random.Range(10f, 70f);
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        return startPos + randomDirection * randomDistance;
    }

    public void TakeDamage(int damage)
    {
        healthController.TakeDamage(damage);
        if (healthController.health <= 0)
        {
            isAlive = false;
            animator.SetTrigger("Death");
        }
    }
}
