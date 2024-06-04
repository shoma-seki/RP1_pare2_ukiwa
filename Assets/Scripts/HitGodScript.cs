using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitGodScript : MonoBehaviour
{
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
        if (gameObject.transform.parent.GetComponent<GodScript>().isCombo == true)
        {
            if (collision.gameObject.tag == "Person")
            {
                collision.gameObject.GetComponent<PersonScript>().SetState(PersonScript.PersonSTATE.Float);
            }
        }
    }
}
