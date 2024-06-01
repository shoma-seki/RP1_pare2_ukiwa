using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private int score;
    private int combo;
    private float comboTime;
    public float kComboTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("score" + score);
        Debug.Log("combo" + combo);
        comboTime -= Time.deltaTime;
        if (comboTime < 0)
        {
            comboTime = 0;
            combo = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Person")
        {
            if (comboTime >= 0)
            {
                combo++;
                score += combo;
            }
            else
            {
                score++;
            }
            collision.GetComponent<PersonScript>().SetFalse();
        }
    }
}
