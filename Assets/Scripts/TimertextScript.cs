using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class TimertextScript : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float gameTime;

    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.Find("GameManagerObject");
    }

    // Update is called once per frame
    void Update()
    {
        gameTime = gameManager.GetComponent<GameManagerScript>().gameTime;
        timerText.text = gameTime.ToString("f1");
    }
}
