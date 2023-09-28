using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject enemy;
    public GameObject boost;
    public GameObject bg0;
    public GameObject bg1;
    public GameObject player;
    private float platformDistance = 0.1f;
    private float enemyDistance = 100f;
    private Vector3 lastPos = new Vector3(0,10f,0);
    private Vector3 enemyLastPos = new Vector3(0,10f,0);
    
    // varaible to store the last position of the platform
    private Vector3 cameraLastPos = new Vector3(0, 0, 0);

    void Start(){
        // set the cameraLastPos to the camera's current position
        cameraLastPos = Camera.main.transform.position;
    }

    // Start is called before the first frame update
    // void Start()
    // {
    //     for ( int i = -10; i < 10; i+=2){
    //         Instantiate(platform, new Vector3(Random.Range(-8f, 8f), Camera.main.transform.position.y + Random.Range(i*1f,i+3f), 0), Quaternion.identity);
    //     }
    // }
    
    void Update()
    {
        SpawnPlatform();
        SpawnEnemy();
        MoveBG();
    }

    void SpawnPlatform()
    {
        if(platformDistance >= 2.0f){
            platformDistance = 2.0f;
        }

        if(lastPos.y + platformDistance < Camera.main.transform.position.y + 10f)
        {
            lastPos = new Vector3(Random.Range(-8f, 8f), Camera.main.transform.position.y + 10f + platformDistance, 0);


            Instantiate(platform, lastPos, Quaternion.identity);

            // generate a random number from 1 to 100, if 100 is generated, spawn a boost
            int rand = Random.Range(1, 21);
            if (rand == 20) 
            {
                Instantiate(boost, lastPos + Vector3.up * 0.5f, Quaternion.identity);
            }
            platformDistance += 0.0025f;
        }
    }

    void SpawnEnemy()
    {
        // If the camera's y position is less than 100, don't spawn enemies
        // if (Camera.main.transform.position.y < 100f)
        // {
        //     return;
        // }

        if (enemyDistance <= 100f)
        {
            enemyDistance = 100f;
        }

        if (enemyLastPos.y + enemyDistance < Camera.main.transform.position.y + 10f)
        {
            enemyLastPos = new Vector3(Random.Range(-8f, 8f), Camera.main.transform.position.y + 10f, 0);

            Instantiate(enemy, enemyLastPos, Quaternion.identity);
            enemyDistance -= 75f;
            enemy.GetComponent<Enemy>().movespeed = Random.Range(1f, 5f);
        }
    }
    // a void function that moves the lowest bg to the top when the bg is lower than the cameras y position - 10
    void MoveBG()
    {
        float bgSpeed = 0f;
        
        // check if the camera's y position is greater than the cameraLastPos y position
        if (Camera.main.transform.position.y > cameraLastPos.y)
        {
            bgSpeed = 0f + (Camera.main.transform.position.y - cameraLastPos.y) / Time.deltaTime;
            // if it is, move the cameraLastPos to the camera's current position
            cameraLastPos = Camera.main.transform.position;
        }
        
        bg0.transform.position -= Vector3.up * bgSpeed * Time.deltaTime;
        bg1.transform.position -= Vector3.up * bgSpeed * Time.deltaTime;

        if (bg0.transform.position.y + 10 < Camera.main.transform.position.y - 10)
        {
            bg0.transform.position = bg1.transform.position + Vector3.up * 20;
        }
        else if (bg1.transform.position.y + 10 < Camera.main.transform.position.y - 10)
        {
            bg1.transform.position = bg0.transform.position + Vector3.up * 20;
        }
    }
}
