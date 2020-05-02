using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    public float timer = 1;
    public GameObject menuText;

    private void Update()
    {
        if (timer < 0)
        {
            menuText.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
