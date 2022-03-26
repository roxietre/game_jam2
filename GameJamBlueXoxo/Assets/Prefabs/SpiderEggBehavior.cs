using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEggBehavior : MonoBehaviour
{
    public int health = 100;
    public float spawnRate = 1f;
    public float spawnTimer = 0f;
    public GameObject normalSpider;
    public GameObject eSpider;

    // a function that is called every 2 seconds and instantiates a normalSpider every seconds and a eSpider every 2 seconds
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0f;
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(normalSpider, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(eSpider, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            BulletScript bs = other.gameObject.GetComponent<BulletScript>();
            health -= bs.damage;
        }    
    }

}
