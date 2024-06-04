using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private int score;
    private int combo;
    private float comboTime;
    public float kComboTime;

    private bool isCombo;

    public GameObject run;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("score" + score);
        Debug.Log("combo" + combo);
        if (combo > 0)
        {
            comboTime -= Time.deltaTime;
        }
        if (comboTime < 0)
        {
            comboTime = kComboTime;
            combo = 0;
        }

        if (combo >= 3)
        {
            isCombo = true;
        }
        else
        {
            isCombo = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Person")
        {
            player.gameObject.GetComponent<PlayerScript>().AddFloatRing();
            combo++;
            score += combo;
            Instantiate(run, collision.transform.position, Quaternion.identity);
            collision.GetComponent<PersonScript>().SetFalse();
        }
    }

    public bool GetIsCombo() { return isCombo; }
}
