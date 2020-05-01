using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFire : MonoBehaviour
{
    public int numObjects = 10;
    public GameObject fire;

    public void GenerateFireElement(float radius)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "fire")
            {
                Destroy(transform.GetChild(i).gameObject);
            }        
        }

        Vector3 center = transform.position;
        for (int i = 0; i < numObjects; i++)
        {
            Vector3 pos = RandomCircle(center, radius);
            GameObject fireClone = Instantiate(fire, pos, Quaternion.identity, transform) as GameObject;
            float angle = 90 + Mathf.Atan2(fireClone.transform.position.y - transform.position.y, fireClone.transform.position.x - transform.position.x) * 180 / Mathf.PI;
            fireClone.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
