using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform Player;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        if(Player == null)
        {
            return;
        }
        // if the players velocity is > 0 scoreText.text = Player.position.y.ToString("0");
        if (float.Parse(scoreText.text) < Player.position.y * 10)
        {
            scoreText.text = (Player.position.y * 10).ToString("0");
        }

    }
}
