using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector3 mousePos;
    public Camera PlayerCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Get input from keyboard
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = PlayerCam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
    }
}
