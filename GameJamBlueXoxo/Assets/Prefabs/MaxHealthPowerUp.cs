using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            ph.maxHealth += 10;
            ph.health += 10;
            Destroy(gameObject);
        }
    }
}
