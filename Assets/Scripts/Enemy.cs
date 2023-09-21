using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
    }
}
