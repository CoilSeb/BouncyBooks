using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;    

public class GameManager : MonoBehaviour
{
    public void EndGame()
    {
        Debug.Log("Game Over");
        // go to a new scene named GameOver
        SceneManager.LoadScene("GameOver");
        // if a button is pressed, restart the game
        if (Input.anyKey)
        {
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
