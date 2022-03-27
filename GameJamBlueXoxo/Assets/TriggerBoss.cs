using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    public GameObject boss;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            boss.GetComponent<Boss1Behavior>().TakeDamage(other.gameObject.GetComponent<BulletScript>().damage);
        }
    }
}
