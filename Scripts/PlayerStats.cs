using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;

    public GameObject GameStartScreen;
    public GameObject GameOverScreen;

    public TMP_Text DeathScore;
    public TMP_Text HighScoreText;

    

    bool died;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        died = false;
        GameStartScreen.SetActive(true);
        GameOverScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameStartScreen.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            StartButton();

        }
    }

    //On collision trigger this script
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player object collides with item tagged pipe update scoreText 
        if (collision.tag == "Pipe")
        {
            score++;
            scoreText.text = "" + score;
            DeathScore.text = "" + score;
        }
        //if you collide with anything die
        else { Die(); }
    }
    public void Die()
    {
        //Debug prints in console whatever is in the " "
        Debug.Log("You Died");

        GameOverScreen.SetActive(true);
        Time.timeScale = 0;
        died = true; 
        HighScoreUpdate();
 
    }

    public void HighScoreUpdate()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            int savedHighScore = PlayerPrefs.GetInt("SavedHighScore");

            // Check if the current score is higher than the saved high score
            if (score > savedHighScore)
            {
                // Update the high score in PlayerPrefs
                PlayerPrefs.SetInt("SavedHighScore", score);
                // Update DeathScore.text to display current score
                DeathScore.text = score.ToString();
                // Update HighScoreText to display the new high score
                HighScoreText.text = score.ToString();
            }
            else
            {
                // Don't update the high score, display the saved high score
                DeathScore.text = score.ToString();
                HighScoreText.text = savedHighScore.ToString();
            }
        }
        else
        {
            // No previous high score, set the current score as high score
            PlayerPrefs.SetInt("SavedHighScore", score);
            DeathScore.text = score.ToString();
            HighScoreText.text = score.ToString();
        }
    }

    public void StartButton()
    {
        if (died)
        {
            // If the player died, reload the scene to restart the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            // If the game hasn't started yet, hide the GameStartScreen and start the game
            GameStartScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is quitting");
    }
}


