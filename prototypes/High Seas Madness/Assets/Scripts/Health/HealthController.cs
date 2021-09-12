using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public HealthBar healthBar;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }
}
