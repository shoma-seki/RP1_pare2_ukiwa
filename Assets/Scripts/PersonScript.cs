using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.UIElements;

public class PersonScript : MonoBehaviour
{
    enum PersonSTATE
    {
        Help, FloatPull, Float
    }
    private int State = (int)PersonSTATE.Help;

    public Sprite sprite1; // 新しいスプライト1
    public Sprite sprite2; // 新しいスプライト2

    private SpriteRenderer spriteRenderer;
    private Collider2D Collider2D;
    private Rigidbody2D Rigidbody2;

    private Vector2 position;
    private Vector2 velocity = Vector2.zero;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider2D = GetComponent<Collider2D>();
        Rigidbody2 = GetComponent<Rigidbody2D>();
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (State == (int)PersonSTATE.Help)
        {
            Collider2D.isTrigger = true;
        }
        if (State == (int)PersonSTATE.Float || State == (int)PersonSTATE.FloatPull)
        {
            // Collider2D.isTrigger = false;
        }
        if (State == (int)PersonSTATE.FloatPull && Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
        {
            velocity = Vector2.down;
        }
        if (State == (int)PersonSTATE.FloatPull && Input.GetKeyUp(KeyCode.Space))
        {
            State = (int)PersonSTATE.Float;
        }

        position += velocity * speed * Time.deltaTime;
        transform.position = position;
        //Rigidbody2.position = position;

        velocity = Vector2.zero;


        //Debug.Log(Collider2D.isTrigger);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FloatRing")
        {
            //Debug.Log(collision.GetComponent<FloatRingScript>().GetState());
            if (collision.GetComponent<FloatRingScript>().GetState() == (int)FloatRingScript.STATE.False)
            {
                ChangeSprite(sprite2);
                if (State == (int)PersonSTATE.Help)
                {
                    State = (int)PersonSTATE.FloatPull;
                }
            }
        }
        if (collision.gameObject.tag == "Person")
        {
            Debug.Log("person");
            if (State == (int)PersonSTATE.FloatPull && Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
            {
                collision.gameObject.GetComponent<PersonScript>().SetVelocity(Vector2.down * speed);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Person")
        {
            Debug.Log("person");
            //collision.gameObject.GetComponent<PersonScript>().SetVelocity(velocity);
        }
    }

    void ChangeSprite(Sprite newSprite)
    {
        // オブジェクトのスプライトを変更
        spriteRenderer.sprite = newSprite;
    }

    public void SetVelocity(Vector2 velocity) { this.velocity = velocity; }
}
