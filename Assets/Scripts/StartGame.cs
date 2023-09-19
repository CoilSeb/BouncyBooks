using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(PlayGame);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            PlayGame();
        }
    }

    public void PlayGame()
    {
        // load the game scene  
        UnitySceneManager.LoadScene("Game");   
    }
}
