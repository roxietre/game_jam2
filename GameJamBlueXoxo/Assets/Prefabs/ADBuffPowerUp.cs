using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADBuffPowerUp : MonoBehaviour
{
    public int buff = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BulletScript bs = other.GetComponent<BulletScript>();
            bs.damage += buff;
            Destroy(gameObject);
        }
    }
}
