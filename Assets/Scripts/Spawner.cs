using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject enemy;
    public GameObject boost;
    private float platformDistance = 0.1f;
    private float enemyDistance = 100f;
    private Vector3 lastPos = new Vector3(0,10f,0);
    private Vector3 enemyLastPos = new Vector3(0,10f,0);


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
}
