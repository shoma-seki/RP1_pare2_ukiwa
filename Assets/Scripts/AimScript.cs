using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class AimScript : MonoBehaviour
{
    private Vector2 position;
    //private Vector2 velocity;
    [SerializeField] float speed;
    private GameObject playerObjct;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        playerObjct = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            position += Vector2.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            position += Vector2.down * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            position += Vector2.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            position += Vector2.right * speed * Time.deltaTime;
        }

        if (position.x < -13.00f)
        {
            position.x = -13.00f;
        }
        if (position.x > 13.0f)
        {
            position.x = 13.0f;
        }

        if (position.y < -3.8f)
        {
            position.y = -3.8f;
        }
        if (position.y > 7.0f)
        {
            position.y = 7.0f;
        }

        transform.position = position;

        playerObjct.GetComponent<PlayerScript>().SetPosition(position.x);
    }
}
