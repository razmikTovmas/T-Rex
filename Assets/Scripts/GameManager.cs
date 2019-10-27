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

    long counter;
    bool isGameOver = false;


    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Debug.Log("Game Over!");
        Invoke("Restart", restartDelay);
    }

    void Restart()
    {
        // SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Main");
    }

    void FixedUpdate()
    {
        if (isGameOver) return;
        if (counter > 30)
        {
            ++score;
            scoreText.text = score.ToString();
            counter = 0;
        }
        ++counter;
    }
}
