using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float startingTime;

    private Text theText;

    void Start()
    {
        theText = GetComponent<Text>();
    }

    void Update()
    {
        startingTime -= Time.deltaTime;
        theText.text = "" + Mathf.Round(startingTime);    
    }
}
