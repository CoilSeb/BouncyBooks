using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreText; // Notice the type is Text, not GameObject
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        if (playerTransform == null)
        {
            Debug.LogError("Player not found in the scene.");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            scoreText.text = playerTransform.position.y.ToString("0");
        }
    }
}
