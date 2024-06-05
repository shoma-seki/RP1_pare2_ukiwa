using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
   public float gameTime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= 0)
        {
            gameTime = 0;
        }
        if (gameTime == 0)
        {
            FadeManager.Instance.LoadScene("ResultScene", 1.0f);
        }
    }
}
