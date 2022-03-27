using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1ProjectileBehavior : MonoBehaviour
{
    public int damage = 30;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
