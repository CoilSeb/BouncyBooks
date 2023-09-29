using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").transform.position.y > transform.position.y + 0.5f)
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
}
