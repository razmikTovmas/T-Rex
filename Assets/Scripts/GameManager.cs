using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1.0f;
    public ulong score;
    public Text scoreText;
    public Text highestScoreText;
    public Text currentScoreText;
    public Text newText;

    public Canvas gameOver;
    static ulong highestScore = 0;

    long counter;
    float timescale;

    void Start()
    {
        timescale = Time.timeScale;
        gameOver.enabled = false;
        //newText.enabled = false;
        Debug.Log(highestScore);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        Debug.Log("Game Over!");

        currentScoreText.text = scoreText.text;
        ulong c = ulong.Parse(currentScoreText.text);
        Debug.Log(highestScore);
        Debug.Log(c);
        Debug.Log("HS: " + (c > highestScore).ToString());
        if (c > highestScore)
        {
            highestScoreText.text = currentScoreText.text;
            highestScore = c;
            newText.enabled = true;
        }
        else
        {
            highestScoreText.text = highestScore.ToString();
            newText.enabled = false;
        }

        gameOver.enabled = true;

    }

    void Restart()
    {
        // SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Main");
        gameOver.enabled = false;
        Time.timeScale = timescale;
    }

    void FixedUpdate()
    {
        if (counter > 30)
        {
            ++score;
            scoreText.text = score.ToString();
            counter = 0;
        }
        ++counter;
        if (score % 50 == 0)
        {
            Time.timeScale += timescale * 0.01f;
        }
    }
}
