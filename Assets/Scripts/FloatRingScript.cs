using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FloatRingScript : MonoBehaviour
{
    public enum STATE
    {
        Push, Float, False
    }

    [SerializeField] float speed;

    private int State = (int)STATE.Push;

    private Vector2 aimPosition;
    private Vector2 position;

    private Vector2 direction;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject aim = GameObject.FindWithTag("Aim");
        position = player.transform.position;
        aimPosition = aim.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (State == (int)STATE.Push && Input.GetKey(KeyCode.Space))
        {
            direction = aimPosition - position;
            velocity = direction.normalized * speed;
            position += velocity * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            State = (int)STATE.Float;
        }
        if (State != (int)STATE.False)
        {
            if ((Mathf.Abs(aimPosition.x - position.x) <= 0.3f && Mathf.Abs(aimPosition.y - position.y) <= 0.3f))
            {
                State = (int)STATE.Float;
            }
        }
        if (State == (int)STATE.False)
        {
            DestroySelf();
        }

        transform.position = position;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Person")
        {
            if (State == (int)STATE.Float)
            {
                if (other.gameObject.GetComponent<PersonScript>().GetState() == (int)PersonScript.PersonSTATE.Help || other.gameObject.GetComponent<PersonScript>().GetState() == (int)PersonScript.PersonSTATE.Approach)
                {
                    if (Input.GetKey(KeyCode.Space) == false)
                    {
                        other.gameObject.GetComponent<PersonScript>().SetState(PersonScript.PersonSTATE.Float);
                    }

                    if (Input.GetKey(KeyCode.Space) == true)
                    {
                        other.gameObject.GetComponent<PersonScript>().SetState(PersonScript.PersonSTATE.FloatPull);
                    }
                    other.gameObject.GetComponent<PersonScript>().SetTargetPosition(new Vector2(-100, -100));
                    State = (int)STATE.False;
                }
            }
        }
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    public int GetState() { return State; }
}
