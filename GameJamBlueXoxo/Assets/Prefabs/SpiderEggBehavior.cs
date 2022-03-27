using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEggBehavior : MonoBehaviour
{
    public int health = 100;
    public float spawnRate = 2f;
    private float spawnTimer = 0f;
    public GameObject normalSpider;
    public GameObject eSpider;
    private Transform player;
    public bool inRange;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;  
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (inRange) {
            if (spawnTimer >= spawnRate)
            {
                spawnTimer = 0f;
                int randomSpider = Random.Range(0, 2);
                if (randomSpider == 0)
                {
                    Instantiate(normalSpider, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(eSpider, transform.position, Quaternion.identity);
                }
            }
        }

        if (health <= 0)
        {
            Destroy(gameObject);
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
