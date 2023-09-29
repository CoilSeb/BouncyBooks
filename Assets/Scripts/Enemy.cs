using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movespeed;
    private bool moveRight = true;

    // Update is called once per frame

    void Start()
    {
        movespeed = Random.Range(1f, 5f);
    }

    void Update()
    {
        if(moveRight)
        {
            transform.position += Vector3.right * movespeed * Time.deltaTime;
            if (transform.position.x > 6.5f)
            {
                moveRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * movespeed * Time.deltaTime;
            if (transform.position.x < -6.5f)
            {
                moveRight = true;
            }
        }
        

        if (transform.position.y < Camera.main.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }
}
