using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUpScript : MonoBehaviour
{
    public int heal = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph.health < ph.maxHealth)
            {
                ph.health += heal;
                if (ph.health > ph.maxHealth)
                {
                    ph.health = ph.maxHealth;
                }
            }
            Destroy(gameObject);
        }
    }
}
