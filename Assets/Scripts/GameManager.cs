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
    public Button restartButton;
    public GameObject player;

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(false);
    }
    public void EndGame()
    {
        Debug.Log("Game Over");

        GameOverText.text = "Game Over";
        buttonText.text = "Press Space to Restart";
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if(player == null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartGame();
            }
        }
    }
}
