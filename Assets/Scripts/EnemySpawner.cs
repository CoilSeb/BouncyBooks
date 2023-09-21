using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private float distance = 2f;
    private Vector3 lastPos = new Vector3(0,10f,0);
    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if(lastPos.y + distance < Camera.main.transform.position.y + 10f)
        {
            lastPos = new Vector3(Random.Range(-8f, 8f), Camera.main.transform.position.y + 10f + distance, 0);

            Instantiate(enemy, lastPos, Quaternion.identity);
            distance += 100f;
        }
    }
}
