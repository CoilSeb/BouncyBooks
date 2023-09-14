using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform Player;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        // how to convert string to float: float.Parse(scoreText.text)
        // if the players velocity is > 0 scoreText.text = Player.position.y.ToString("0");
        if (float.Parse(scoreText.text) < Player.position.y)
        {
            scoreText.text = Player.position.y.ToString("0");
        }

    }
}
