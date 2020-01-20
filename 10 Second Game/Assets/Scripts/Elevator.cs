using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Vector2 posA;
    public Vector2 posB;

    void Update()
    {
        transform.position = Vector3.Lerp(posA, posB, Mathf.PingPong(Time.time, 2f));
    }
}
