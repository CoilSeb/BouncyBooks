using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;  

public class GameManager : MonoBehaviour
{
    public GameObject button;
    public GameObject GameOverText;
    public Text buttonText;
    public void EndGame()
    {
        Debug.Log("Game Over");

        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
