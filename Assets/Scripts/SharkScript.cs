using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SharkScript : MonoBehaviour
{
    public enum SharkSTATE
    {
        Normal, Approach, Float, False
    }
    private SharkSTATE state = SharkSTATE.Normal;

    [SerializeField] private float speed;
    private Vector2 position;
    private Vector2 targetPosition = new Vector2(-100, -100);
    private Vector2 direction;
    private Vector2 startDirection;
    private Vector2 velocity;

    private SpriteRenderer spriteRenderer;

    public Sprite shark;
    public Sprite floatShark;

    public float kFloatTime;
    private float floatTime;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        position = transform.position;
        if (transform.position.x < 0)
        {
            startDirection = Vector2.right;
        }
        if (transform.position.x > 0)
        {
            startDirection = Vector2.left;
        }
        direction = startDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPosition != new Vector2(-100, -100) && state == SharkSTATE.Normal)
        {
            state = SharkSTATE.Approach;
        }

        if (state == SharkSTATE.Normal)
        {
            velocity = direction.normalized * speed * Time.deltaTime;
            position += velocity;
            transform.position = position;
        }
        if (state == SharkSTATE.Approach)
        {
            direction = targetPosition - position;
            velocity = direction.normalized * speed * Time.deltaTime;
            position += velocity;
            transform.position = position;
            if (Mathf.Abs(targetPosition.x - transform.position.x) <= 1 && Mathf.Abs(targetPosition.y - transform.position.y) <= 1)
            {
                state = SharkSTATE.Normal;
            }
        }
        if (state == SharkSTATE.Float)
        {
            direction = Vector2.zero;
            floatTime += Time.deltaTime;
            if (floatTime >= kFloatTime)
            {
                state = SharkSTATE.Normal;
                floatTime = 0;
                direction = startDirection;
            }
        }
        if (state == SharkSTATE.False)
        {
            DestroySelf();
        }
        if (velocity.x > 0)
        {
            spriteRenderer.flipX = true;
        }

        SpriteState();
    }

    private void SpriteState()
    {
        if (state == SharkSTATE.Normal || state == SharkSTATE.Approach)
        {
            ChangeSprite(shark);
        }
        if (state == SharkSTATE.Float)
        {
            ChangeSprite(floatShark);
        }
    }

    private void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Person")
        {
            if (collision.gameObject.GetComponent<PersonScript>().GetState() != (int)PersonScript.PersonSTATE.False)
            {
                collision.gameObject.GetComponent<PersonScript>().SetIsSharkCollision(true);
                state = SharkSTATE.False;
            }
        }
    }

    public void SetTargetPosition(Vector2 targetPosition) { this.targetPosition = targetPosition; }
    private void DestroySelf() { Destroy(this.gameObject); }
    public int GetState() { return (int)state; }
    public void SetState(SharkSTATE state) { this.state = state; }
}
