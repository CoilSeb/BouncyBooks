using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // if the players position is greater than the platforms position, set platform collider to true
        if (GameObject.Find("Player").transform.position.y > transform.position.y + 0.75f)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else if(GameObject.Find("Player").transform.position.y < transform.position.y)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }

        // if the platform is less than the camera, destroy the platform
        if (transform.position.y < Camera.main.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }
}
