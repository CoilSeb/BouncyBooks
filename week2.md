### Week 2
* Camera 
* Platform / Platform Spawner
* Score
* Game Over

## Camera
* Select the `Camera` and change the `Size` to 10
* Copy and paste our platform at least twice
* In the Player script, add the following code to the `Update` function:
```cs
    if(rb.velocity.y > 0 && /*(and)*/ transform.position.y > Camera.main.transform.position.y)
    {
        Camera.main.transform.position = new Vector3(0, transform.position.y, -10);
    }
```

## Platform
* Create a new script called `Platform`
* Create a `Prefabs` folder
* Drag the `Platform` into the `Prefabs` folder
* Drag some platform prefabs into the game scene 
* Set the collider to false at the startof the game so that our player can jump through them
```cs
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
```
* Add the code so that whenever the player is above the platform, the platform collider turns on
```cs
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").transform.position.y > transform.position.y + 1.5f)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else if(GameObject.Find("Player").transform.position.y < transform.position.y)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
```
* Add in the end of the update function to delete platforms as they leave the screen
```cs
    if (transform.position.y < Camera.main.transform.position.y - 10)
    {
        Destroy(gameObject);
    }
```

## Spawner
* Create a new game object called `Spawner`
* Create a new script called `Spawner`
* We want to create new platforms at the top of the camera
* Add the platform (Drag from Prefabs folder) to the script as well as a few variables 
```cs
    public GameObject platform;
    private float platformDistance = 0.5f; /*Vertical distance we want between platform spawns */
    private Vector3 lastPos = new Vector3(0,10f,0); /*Position of the last platform spawned*/
```
* Create a new function called `SpawnPlatform`
```cs
    void SpawnPlatform()
    {
        // We want the platform distance to be no more than 2 so that platforms spawn close enough to jump on
        if(platformDistance >= 2.0f){
            platformDistance = 2.0f;
        }

        //A simple check to stop from spawning platforms while the camera doesnt move
        if(lastPos.y + platformDistance < Camera.main.transform.position.y + 10f)
        {
            // Set the last position variable to be slightly above the camera
            lastPos = new Vector3(Random.Range(-6f, 6f), Camera.main.transform.position.y + 10f + platformDistance, 0); 

            // Spawn the platform
            Instantiate(platform, lastPos, Quaternion.identity);

            // Increase the platform distance
            platformDistance += 0.0025f;
        }
    }
```

## Score
* Set the game aspect ratio to `16:9`
# Fixing Canvas / Adding Borders
* Create a new `Canvas`
* Change `UI Scale Mode` to `Scale With Screen Size`
* Change `Reference Resolution` to `1920 x 1080`
* Change `Screen Match Mode` to `Shrink`
* Add a new `RawImage` called `Border`
* Set the color to black, height to `1080` and width to `1920/3`
* Change the platform prefab to a width of `3`
# Creating Score
* Right click on `Canvas` and add a new `UI: Legacy: Text` named `Score`
* Double click canvas to put it into view
* Resize the score text box, set the font to 78pt, change the text to `0`, set the text color to white, middle align
* Add a new script to Score called `Score`
* Add this to the libraraies at the top so that we can use them
```cs
using UnityEngine.UI;  
```
* Add these variables to gain access to the players transform and the text of the score
```cs
    public Transform Player;
    public Text scoreText;
```
* Edit the `Update` function to change the text as the players y position rises
```cs
    void Update()
    {
        // if the player does not exist, do nothing
        if(Player == null)
        {
            return;
        }
        // if the players position is > scoreText, change the scoreText to the playres position
        if (float.Parse(scoreText.text) < Player.position.y /* * 10*/)
        {
            scoreText.text = (Player.position.y /* * 10*/).ToString("0");
        }

    }
```

## Game Over
# Adding Game Over Text
* Create a new `UI: Legacy: Text` named `GameOver` to your canvas
* Resize the textbox, set the text to ``, size 78, white color, middle align
* Create a new game object in your scene with `Create Empty` called `GameManager`
* Add a script to it called `GameManager`
* Add this to the libraraies at the top so that we can use them
```cs
using UnityEngine.SceneManagement; 
using UnityEngine.UI;  
```
* Add the following variables and drag them into the script within Unity
```cs
    public Text GameOverText;
    public GameObject player;
```
* Add a function `EndGame` that destroys the player, destroys all platforms and displays `Game Over`
```cs 
    public void EndGame()
    {
        Destroy(player);

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject platform in platforms)
        {
            Destroy(platform);
        }

        GameOverText.text = "Game Over";
    }
```
# Adding the destruction of the player
* Add the following code to the player script in the update function
```cs
    // if the player drops lower than the camera, the game is over
    if (transform.position.y < Camera.main.transform.position.y - 10) 
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().EndGame();
    }
```
# Adding Restart Mechanic/Button
* Create a new `UI: Legacy: Button` called `RestartButton` to your canvas
* Resize 
* Rename the text to `RestartText`
* Resize the text box, set the font to 52pt, change the text to ``, set the text color to black, middle align
* Update the GameManager script to activate the button upon death
* Add the following variables and drag them into the script within Unity
```cs
    public Text buttonText;
    public Button restartButton;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(false);
    }
```
* Edit the EndGame function to include the following script
```cs
    buttonText.text = "Press Space to Restart";
    restartButton.gameObject.SetActive(true);
```
* Add the following code to the Update function so that we can press space to restart the game
```cs
    // if the player no longer exist
    if(player == null)
    {
        // if the player presses space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // call our restart function
            RestartGame();
        }
    }
```