using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject pauseMenu, gameOverMenu;

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }
}
