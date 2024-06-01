using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCircleScript : MonoBehaviour
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
        if (collision.gameObject.tag == "Person")
        {
            if (IsFirstCollision)
            {
                gameObject.transform.parent.GetComponent<SharkScript>().SetTargetPosition(collision.transform.position);
                IsFirstCollision = false;
            }
        }
    }
}
