using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FadeManager.Instance.LoadScene("GameScene", 0.5f);
        }
    }
}
