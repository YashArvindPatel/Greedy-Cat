using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public int forceX, forceY;
    public Vector3 _origPos;

    public GameObject coin1, coin2, coin3;

    public int coinCount = 0;

    public float radius;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreDisplayText;
    public TextMeshProUGUI bestScoreDisplayText;

    public AudioSource audioSource;
    public AudioClip coinCollect;
    public AudioClip loseSound;
    public AudioClip clickSound;

    public bool toClick = true;
    public bool vibrate = true;

    public int score = 0;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("volume") == 1)
        {
            audioSource.Play();
        }
        else if (PlayerPrefs.GetInt("volume") == 0)
        {
            audioSource.Stop();
        }

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            toClick = true;
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            toClick = false;
        }

        if (PlayerPrefs.GetInt("vibrate") == 1)
        {
            vibrate = true;
        }
        else if (PlayerPrefs.GetInt("vibrate") == 0)
        {
            vibrate = false;
        }
    }

    private void Start()
    {
        bestScoreDisplayText.text = "Best Score: " + PlayerPrefs.GetInt("highScore");
        audioSource = GetComponent<AudioSource>();
        _origPos = transform.position;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));

        if (Screen.width == 480 && Screen.height == 800)
        {
            radius = 2.2f;
        }
        else if ((Screen.width == 720 && Screen.height == 1280) || (Screen.width == 1080 && Screen.height == 1920))
        {
            radius = 2.08f;
        }
        else if ((Screen.width == 1080  && Screen.height == 2160) || (Screen.width == 1440 && Screen.height == 2960))
        {
            radius = 1.85f;
        }
        else if (Screen.width == 1440 && Screen.height == 2560)
        {
            radius = 2.1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);

        StartCoroutine(GenerateStuff());
    }

    IEnumerator GenerateStuff()
    {
        yield return new WaitForSeconds(0.2f);

        FindObjectOfType<GenerateFire>().GenerateFireElement(radius);

        if (coinCount < 3)
        {
            coinCount++;
            int random = Random.Range(0, 3);
            if (random == 0)
            {
                FindObjectOfType<GenerateCoins>().GenerateCoin(coin1, radius);
            }
            else if (random == 1)
            {
                FindObjectOfType<GenerateCoins>().GenerateCoin(coin2, radius);
            }
            else if (random == 2)
            {
                FindObjectOfType<GenerateCoins>().GenerateCoin(coin3, radius);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            score++;
            scoreText.text = score.ToString();
            scoreDisplayText.text = "Score: " + score;
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                bestScoreDisplayText.text = "Best Score: " + score;
            }
            coinCount--;
            audioSource.PlayOneShot(coinCollect);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "fire")
        {
            if (PlayerPrefs.GetInt("highScore") < score)
            {
                PlayerPrefs.SetInt("highScore", score);
            }          

            audioSource.PlayOneShot(loseSound);
            FindObjectOfType<MenuHandler>().GameOver();
        }
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && toClick)
        {
            GetComponent<AudioSource>().PlayOneShot(clickSound);
        }

        Vector3 moveDirection = transform.position - _origPos;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        _origPos = transform.position;
    }
}
