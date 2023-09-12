using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        // starts a platform spawner function
        StartCoroutine(SpawnPlatform());
    }
    
    // platform spawner function
    IEnumerator SpawnPlatform()
    {
        // while the game is running, spawn a platform every 2 seconds
        while (true)
        {
            // make the platforms spawn at a random value (between -20 and 20) above the camera
            // the platforms only spawn when the cameras y value changes
            if(Camera.main.transform.position.y < 250)
            {
                Instantiate(platform, new Vector3(Random.Range(-20, 20), Camera.main.transform.position.y + Random.Range(11,15), 0), Quaternion.identity);
                Instantiate(platform, new Vector3(Random.Range(-20, 20), Camera.main.transform.position.y +  Random.Range(16,20), 0), Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            // else if(Camera.main.transform.position.y > 250 && Camera.main.transform.position.y < 500)
            // {
            //     Instantiate(platform, new Vector3(Random.Range(-20, 20), Camera.main.transform.position.y + 11, 0), Quaternion.identity);
            //     yield return new WaitForSeconds(1.5f);
            // }
            // else
            // {
            //     Instantiate(platform, new Vector3(Random.Range(-20, 20), Camera.main.transform.position.y + 11, 0), Quaternion.identity);
            //     yield return new WaitForSeconds(2f);
            // }
        }
    }
}
