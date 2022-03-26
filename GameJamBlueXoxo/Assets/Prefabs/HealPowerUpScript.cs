using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUpScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph.currentHealth < ph.maxHealth)
            {
                ph.currentHealth += 10;
                if (ph.currentHealth > ph.maxHealth)
                {
                    ph.currentHealth = ph.maxHealth;
                }
            }
            Destroy(gameObject);
        }
    }
}
