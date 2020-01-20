using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
