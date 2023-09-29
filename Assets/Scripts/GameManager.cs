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
        Destroy(GameObject.Find("Player"));

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject platform in platforms)
        {
            Destroy(platform);
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        GameObject[] FakePlatforms = GameObject.FindGameObjectsWithTag("FakePlatform");
        foreach (GameObject FakePlatform in FakePlatforms)
        {
            Destroy(FakePlatform);
        }

        GameObject[] Boosts = GameObject.FindGameObjectsWithTag("Boost");
        foreach (GameObject Boost in Boosts)
        {
            Destroy(Boost);
        }

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
