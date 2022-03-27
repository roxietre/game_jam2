using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Behavior : MonoBehaviour
{
    public int health = 500;
    public int maxHealth = 500;
    public int damage = 50;
    private Rigidbody2D rb;
    private Transform player;
    private Vector2 movement;
    public float speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //spawns a blue pixel
            Destroy(gameObject);
        }
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Bullet")) {
            BulletScript bs = other.gameObject.GetComponent<BulletScript>();
            health -= bs.damage;
        }
    }
}
