using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpHeight = 20f;
    public float movespeed = 15f;
    public Rigidbody2D rb;

    // function for when the object collides with anything, it applies velocity equal to jumpHeight
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        // move the player left if A or the left arrow key is held down
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * movespeed * Time.deltaTime;
        }

        // move the player right if D or the right arrow key is held down
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * movespeed * Time.deltaTime;
        }

        // if the player is moving up and the player is higher than the camera, move the camera up
        if(rb.velocity.y > 0 && transform.position.y > Camera.main.transform.position.y)
        {
            Camera.main.transform.position = new Vector3(0, transform.position.y, -10);
        }

        // if the players position is less than -20 or greater than 20 on the x axis (the bounds of the camera), the player is moved to the other side of the camera
        if (transform.position.x < -8)
        {
            transform.position = new Vector3(8, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 8)
        {
            transform.position = new Vector3(-8, transform.position.y, transform.position.z);
        }

// if the player drops lower than the camera, the game is over
        if (transform.position.y < Camera.main.transform.position.y - 10)
        {
            Destroy(gameObject);

            GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
            foreach (GameObject platform in platforms)
            {
                Destroy(platform);
            }

            GameObject.Find("GameManager").GetComponent<GameManager>().EndGame();
            
        }
        
    }
}