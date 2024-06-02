using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCirclePersonScript : MonoBehaviour
{
    private bool IsFirstCollision = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FloatRing")
        {
            if (IsFirstCollision)
            {
                if (collision.gameObject.GetComponent<FloatRingScript>().GetState() == (int)FloatRingScript.STATE.Float)
                {
                    gameObject.transform.parent.GetComponent<PersonScript>().SetTargetPosition(collision.transform.position);
                    IsFirstCollision = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FloatRing")
        {
            IsFirstCollision = true;
            gameObject.transform.parent.GetComponent<PersonScript>().SetTargetPosition(new Vector2(-100, -100));
        }
    }
}
