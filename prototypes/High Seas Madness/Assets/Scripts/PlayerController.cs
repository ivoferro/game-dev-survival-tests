using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    private InventoryManager inventoryManager;
    private Vector2 movement;
    public LayerMask enemiesLayer;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("Attack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 2, enemiesLayer);
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyAi>().TakeDamage(20);
            }
        }
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * moveSpeed * Time.fixedDeltaTime);
        TriggerAnimmations();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickable"))
        {
            inventoryManager.AddItem(collision.GetComponent<IInventoryItem>());
        }
    }

    private void TriggerAnimmations()
    {
        playerAnimator.SetFloat("Horizontal", movement.x);
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("speed", movement.sqrMagnitude);
        if (movement.sqrMagnitude > 0.01f)
        {
            playerAnimator.SetFloat("HorizontalBeforeIdle", movement.x);
            playerAnimator.SetFloat("VerticalBeforeIdle", movement.y);
        }
    }
}
