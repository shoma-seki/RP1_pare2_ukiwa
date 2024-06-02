using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.UIElements;

public class PersonScript : MonoBehaviour
{
    enum PersonSTATE
    {
        Help, Approach, FloatPull, Float, False
    }
    private PersonSTATE State = PersonSTATE.Help;
    private PersonSTATE PrebState = PersonSTATE.Help;
    private float changeStateCount;

    public Sprite sprite1; // 新しいスプライト1
    public Sprite sprite2; // 新しいスプライト2

    private SpriteRenderer spriteRenderer;
    private Collider2D Collider2D;
    private Rigidbody2D Rigidbody2;

    private Vector2 position;
    private Vector2 targetPosition = new Vector2(-100, -100);
    private Vector2 direction;
    private Vector2 velocity = Vector2.zero;
    [SerializeField] private float speed;
    private float newSpeed;

    private bool isSharkCollision = false;

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
        if (State == PersonSTATE.False)
        {
            DestroySelf();
        }
        if (State == PersonSTATE.Help)
        {
            Collider2D.isTrigger = true;
            if (targetPosition != new Vector2(-100, -100))
            {
                PrebState = State;
                State = PersonSTATE.Approach;
                Debug.Log(PrebState);
            }
        }
        if (targetPosition == new Vector2(-100, -100))
        {
            if (State != PersonSTATE.FloatPull)
            {
                if (PrebState == PersonSTATE.Help)
                {
                    changeStateCount += Time.deltaTime;
                    if (changeStateCount >= 1)
                    {
                        State = PersonSTATE.Help;
                        direction = Vector2.zero;
                        changeStateCount = 0;
                    }
                }
                if (PrebState == PersonSTATE.Float)
                {
                    if (changeStateCount >= 1)
                    {
                        State = PersonSTATE.Float;
                        direction = Vector2.zero;
                        changeStateCount = 0;
                    }
                }
            }
        }
        if (State == PersonSTATE.Approach)
        {
            newSpeed = 1;
            direction = targetPosition - position;
            velocity = direction.normalized * newSpeed;
        }
        else
        {
            newSpeed = speed;
        }
        //if (State == (int)PersonSTATE.Float || State == (int)PersonSTATE.FloatPull)
        //{
        //    // Collider2D.isTrigger = false;
        //}
        if (State == PersonSTATE.FloatPull && Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }
        if (State == PersonSTATE.FloatPull && Input.GetKeyUp(KeyCode.Space))
        {
            State = PersonSTATE.Float;
        }

        velocity = direction.normalized * newSpeed;
        position += velocity * Time.deltaTime;
        transform.position = position;

        direction = Vector2.zero;

        if (isSharkCollision)
        {
            if (State == PersonSTATE.Help)
            {
                State = PersonSTATE.False;
            }
            if (State == PersonSTATE.Float || State == PersonSTATE.FloatPull)
            {
                State = PersonSTATE.Help;
                ChangeSprite(sprite1);
            }
            isSharkCollision = false;
        }

        Debug.Log(State);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FloatRing")
        {
            //Debug.Log(collision.GetComponent<FloatRingScript>().GetState());
            if (collision.GetComponent<FloatRingScript>().GetState() == (int)FloatRingScript.STATE.False)
            {
                ChangeSprite(sprite2);
                if (State == PersonSTATE.Help)
                {
                    State = PersonSTATE.FloatPull;
                }
            }
        }
        if (collision.gameObject.tag == "Person")
        {
            Debug.Log("person");
            if (State == PersonSTATE.FloatPull && Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
            {
                collision.gameObject.GetComponent<PersonScript>().SetDirectionSpeed(Vector2.down, speed);
            }
        }
    }

    void ChangeSprite(Sprite newSprite)
    {
        // オブジェクトのスプライトを変更
        spriteRenderer.sprite = newSprite;
    }

    public void SetDirectionSpeed(Vector2 direcrion, float speed)
    {
        this.direction = direcrion;
        this.newSpeed = speed;
    }

    private void DestroySelf() { Destroy(this.gameObject); }

    public void SetIsSharkCollision(bool isSharkCollision) { this.isSharkCollision = isSharkCollision; }

    public void SetFalse() { State = PersonSTATE.False; }
    public void SetTargetPosition(Vector2 targetPosition) { this.targetPosition = targetPosition; }
}
