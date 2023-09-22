using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float movespeed = 1.25f;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player") != null)
        {
            // if the enemy collider hits the player collider, destroy the player
            if (GetComponent<PolygonCollider2D>().IsTouching(GameObject.Find("Player").GetComponent<BoxCollider2D>()))
            {
                Destroy(GameObject.Find("Player"));
                GameObject.Find("GameManager").GetComponent<GameManager>().EndGame();
            }
        }

        // move the enemy left until it hits a bound then move it right until it hits a bound, have this process repeat indefinitely
        if (transform.position.x < -8)
        {
            movespeed = 1.25f;
        }
        else if (transform.position.x > 8)
        {
            movespeed = -1.25f;
        }
        transform.position += Vector3.right * movespeed * Time.deltaTime;
        

        if (transform.position.y < Camera.main.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }
}
