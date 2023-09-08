using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpHeight = 10f;
    public float movespeed = 0.1f;
    public Rigidbody2D rb;

    // function for when the object collides with anything, it applies velocity equal to jumpHeight
    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
    
    // Update is called once per frame
    void Update()
    {
        // move the player left if A or the left arrow key is held down
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - movespeed, transform.position.y, transform.position.z);
        }

        // move the player right if D or the right arrow key is held down
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + movespeed, transform.position.y, transform.position.z);
        }

        // move the camera and killbox up
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 0.025f, Camera.main.transform.position.z);
        GameObject.Find("KillBox").transform.position = new Vector3(GameObject.Find("KillBox").transform.position.x, GameObject.Find("KillBox").transform.position.y + 0.025f, GameObject.Find("KillBox").transform.position.z);

        // if the player position is less than the KillBox position, destroy the player
        if (transform.position.y < GameObject.Find("KillBox").transform.position.y)
        {
            Destroy(gameObject);
        }
        
    }
}
