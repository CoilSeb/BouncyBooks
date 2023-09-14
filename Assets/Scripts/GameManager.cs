using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;  

public class GameManager : MonoBehaviour
{
    public Image button;
    public Text GameOverText;
    public Text buttonText;
    public void EndGame()
    {
        Debug.Log("Game Over");

        GameOverText.text = "Game Over";
        buttonText.text = "Play Again";
        button.GetComponent<Image>().enabled = true;
    }
}
