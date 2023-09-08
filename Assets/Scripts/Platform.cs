using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // if the players position is greater than the platforms position, set platform collider to true
        if (GameObject.Find("Player").transform.position.y > transform.position.y + 1)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
