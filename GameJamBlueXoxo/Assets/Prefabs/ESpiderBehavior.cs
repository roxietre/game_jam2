using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpiderBehavior : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public int damage = 30;
    private Rigidbody2D rb;
    private Transform player;
    private Vector2 movement;
    public float speed = 3f;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate() 
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle; 
        direction.Normalize();
        movement = direction;
        MoveEnnemy(movement);
    }

    void MoveEnnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();
            ph.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Bullet")) {
            BulletScript bs = other.gameObject.GetComponent<BulletScript>();
            health -= bs.damage;
        }
    }
}
