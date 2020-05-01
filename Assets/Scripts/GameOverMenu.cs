using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI score, highScore;

    public void Start()
    {
        score.text = "Score: " + FindObjectOfType<Game>().score;
        highScore.text = "Best Score: " + PlayerPrefs.GetInt("highScore");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
