using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveMineScript : MonoBehaviour
{
    public int damage = 10;

    private void onTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            ph.currentHealth -= damage;
            Debug.Log("Player health: " + ph.currentHealth);
            Destroy(gameObject);
        }
    }
}
