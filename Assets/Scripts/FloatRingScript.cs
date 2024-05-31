using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FloatRingScript : MonoBehaviour
{
    enum STATE
    {
        Push, Pull, False
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
        if (State == (int)STATE.Push)
        {
            direction = aimPosition - position;
            velocity = direction.normalized * speed;
            position += velocity * Time.deltaTime;
        }
        if (State == (int)STATE.Pull)
        {
            if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
            {
                direction = Vector2.down;
                velocity = direction.normalized * speed;
                position += velocity * Time.deltaTime;
            }
        }

        transform.position = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Person")
        {
            State = (int)STATE.Pull;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Person")
        {
            State = (int)STATE.Pull;
        }
    }
}
