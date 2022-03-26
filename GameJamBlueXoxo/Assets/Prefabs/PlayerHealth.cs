using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public float invincibilityTime = 1f;
    public float invincibilityTimer = 0f;
    public bool isInvincible = false;
    public bool isDead = false;
    public int currentHealth = 100;
    public HealthBarScript healthBar;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            isDead = true;
        }
        if (isDead)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
    }
}
