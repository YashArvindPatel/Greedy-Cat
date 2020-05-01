using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToVibrateOrNot : MonoBehaviour
{
    public void ClickedOnButton()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (FindObjectOfType<MainMenuScript>().vibrate)
            {
                Handheld.Vibrate();
            }
            else
            {
                return;
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (FindObjectOfType<Game>().vibrate)
            {
                Handheld.Vibrate();
            }
        }
    }
}

