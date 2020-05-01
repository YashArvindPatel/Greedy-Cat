using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCoins : MonoBehaviour
{
    public void GenerateCoin(GameObject coin, float radius)
    {
        radius -= .25f;
        Vector3 center = transform.position;
        Vector3 pos = RandomCircle(center, Random.Range(0f, radius));
        Instantiate(coin, pos, Quaternion.identity, transform);
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
