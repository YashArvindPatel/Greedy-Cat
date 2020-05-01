using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCircle : MonoBehaviour
{
    public Transform separation;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x < separation.transform.position.x)
            {
                transform.Rotate(0, 0, 1);
            }
            else
            {
                transform.Rotate(0, 0, -1);
            }
        }      
    }
}
