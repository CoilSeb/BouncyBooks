using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    // function for when the object collides with anything, it applies velocity equal to jumpHeight
    void OnCollisionEnter2D(Collision2D collision) // 2d collision public
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight); // adjust rigidbody velocity
    }
    
    // 2d rigidbody public
    public Rigidbody2D rb;
    // update
    void Update()
    {
            // if space is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                // adjust rigidbody velocity
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
    }
}
