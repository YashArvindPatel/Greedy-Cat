using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public TextMeshProUGUI bestScore;
    public AudioClip clickSound;
    public bool vibrate = true;

    private void OnEnable()
    {
        bestScore.text = "Best Score: " + PlayerPrefs.GetInt("highScore");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            GetComponent<AudioSource>().PlayOneShot(clickSound);
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();

                return;
            }
        }
    }
}
