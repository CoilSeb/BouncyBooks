using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool spawned = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        // move the object 1 pix up per frame
        transform.position -= Vector3.up * Time.deltaTime;
        // spawn a new background object when the current one hits (0,0,0), make sure it is a child of "Main Camera"
        if((-1 <= transform.position.y) && (transform.position.y  <= 0) && !spawned)
        {
            // spawn 15 below the game object
            Instantiate(gameObject, new Vector3(0, transform.position.y + 1, 10), Quaternion.identity, GameObject.Find("Main Camera").transform);
            spawned = true;
        }
        // if object is greater than 100 pix up, destroy it
        if(transform.position.y < -1f)
        {
            Destroy(gameObject);
        }
    }
}
