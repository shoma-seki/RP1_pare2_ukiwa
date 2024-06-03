using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SharkScript : MonoBehaviour
{
    public enum SharkSTATE
    {
        Normal, Approach,Float ,False
    }
    private SharkSTATE state = SharkSTATE.Normal;

    [SerializeField] private float speed;
    private Vector2 position;
    private Vector2 targetPosition = new Vector2(-100, -100);
    private Vector2 direction;
    private Vector2 velocity;

    private SpriteRenderer spriteRenderer;

    public Sprite shark;
    public Sprite floatShark;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        position = transform.position;
        if (transform.position.x < 0)
        {
            direction = Vector2.right;
        }
        if (transform.position.x > 0)
        {
            direction = Vector2.left;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPosition != new Vector2(-100, -100) && state != SharkSTATE.False)
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
        }
        if (state == SharkSTATE.False)
        {
            DestroySelf();
        }
        if (velocity.x > 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Person")
        {
            state = SharkSTATE.False;
            collision.gameObject.GetComponent<PersonScript>().SetIsSharkCollision(true);
        }
    }

    public void SetTargetPosition(Vector2 targetPosition) { this.targetPosition = targetPosition; }
    private void DestroySelf() { Destroy(this.gameObject); }
    public int GetState() { return (int)state; }
    public void SetState(SharkSTATE state) { this.state = state; }
}
