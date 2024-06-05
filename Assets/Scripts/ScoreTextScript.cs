using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private float score;

    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.FindWithTag("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        score = gameManager.GetComponent<GroundScript>().score;
        scoreText.text = score.ToString("f1");
    }
}
