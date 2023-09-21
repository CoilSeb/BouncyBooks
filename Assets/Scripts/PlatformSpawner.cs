using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    private float distance = 0.1f;
    private Vector3 lastPos = new Vector3(0,10f,0);

    // Start is called before the first frame update
    void Start()
    {
        for ( int i = -10; i < 10; i+=2){
            Instantiate(platform, new Vector3(Random.Range(-8f, 8f), Camera.main.transform.position.y + Random.Range(i*1f,i+3f), 0), Quaternion.identity);
        }
    }
    
    void Update()
    {
        SpawnPlatform();
    }

    void SpawnPlatform()
    {
        if(distance >= 2.0f){
            distance = 2.0f;
        }

        if(lastPos.y + distance < Camera.main.transform.position.y + 10f)
        {
            lastPos = new Vector3(Random.Range(-8f, 8f), Camera.main.transform.position.y + 10f + distance, 0);

            Instantiate(platform, lastPos, Quaternion.identity);
            distance += 0.01f;
        }
    }
}
