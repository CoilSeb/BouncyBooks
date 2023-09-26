using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private bool moveRight = true;
    private float movespeed = 5f;

    public enum PlatfromType
    {
        Normal, 
        Fake, 
        Moving,
        Disappearing
    }

    public PlatfromType platformType = PlatfromType.Normal;

    void NormalLogic()
    {
        if (GameObject.Find("Player").transform.position.y > transform.position.y + 0.75f)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else if(GameObject.Find("Player").transform.position.y < transform.position.y)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }

        if (transform.position.y < Camera.main.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }

    void MoveLogic()
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "FakePlatform")
        {
            Destroy(gameObject);
        }

        if(platformType == PlatfromType.Disappearing)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (transform.position.y < 25)
        {
            platformType = PlatfromType.Normal;
        }
        else
        {
            platformType = (PlatfromType)Random.Range(0, 6);

            if (platformType == PlatfromType.Fake)
            {
                gameObject.tag = "FakePlatform";
                GetComponent<SpriteRenderer>().color = Color.red;
            }

            if (platformType == PlatfromType.Moving)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
            }

            if (platformType == PlatfromType.Disappearing)
            {
                GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (platformType)
        {
            case PlatfromType.Normal:
                break;
            case PlatfromType.Moving:
                MoveLogic();
                break;
            case PlatfromType.Disappearing:
                break;
            case PlatfromType.Fake:
                break;
            default:
                break;
        }

        NormalLogic();

        // if the platform is less than the camera, destroy the platform
        if (transform.position.y < Camera.main.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }
}
