using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    PlayerFire pf;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            pf = other.GetComponent<PlayerFire>();
            if (pf.fireRate <= 0.1f)
            {
                pf.fireRate = 0.1f;
            }
            else
                pf.fireRate -= 0.1f;
            if (pf.fireRate <= 0.1f)
            {
                pf.fireRate = 0.1f;
            }

            Destroy(gameObject);
        }    
    }
}
