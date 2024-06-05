using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.UIElements;

public class PersonScript : MonoBehaviour
{
    public enum PersonSTATE
    {
        Help, Approach, FloatPull, Float, Forrow, False
    }
    private PersonSTATE State = PersonSTATE.Help;
    private PersonSTATE preState = PersonSTATE.Help;
    private bool isCollisionFloatPull;
    private float changeTime;

    public Sprite helpSprite;
    public Sprite floatSprite;
    public Sprite floatPullSprite;
    public Sprite ApproachSprite;
    public Sprite ForrowSprite;

    private SpriteRenderer spriteRenderer;
    private Collider2D Collider2D;
    private Rigidbody2D Rigidbody2;

    private Vector2 position;
    private Vector2 targetPosition = new Vector2(-100, -100);
    private Vector2 direction;
    private Vector2 velocity = Vector2.zero;
    [SerializeField] private float NormalSpeed;
    [SerializeField] private float ApproachSpeed;
    private float speed;

    private bool isSharkCollision = false;

    [SerializeField] ParticleSystem particle;
    private float startTime;

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
        startTime += Time.deltaTime;
        particle.Play();
        if (startTime >= 2)
        {
            particle.Stop();
        }
        SpriteState();

        if (State == PersonSTATE.False)
        {
            DestroySelf();
        }
        if (State == PersonSTATE.Help)
        {
            Collider2D.isTrigger = true;
            direction = Vector2.zero;
            changeTime = 0;
        }
        if (State == PersonSTATE.Float)
        {
            changeTime += Time.deltaTime;
            if (changeTime > 1)
            {
                direction = Vector2.zero;
                targetPosition = new Vector2(-100, -100);
            }
        }
        if (isCollisionFloatPull)
        {
            State = PersonSTATE.Forrow;
        }
        if (State == PersonSTATE.Forrow)
        {
            direction = Vector2.down;
        }
        if (targetPosition != new Vector2(-100, -100))
        {
            if (State == PersonSTATE.Help)
            {
                State = PersonSTATE.Approach;
                speed = ApproachSpeed;
            }
        }
        //アプローチから抜ける
        if (targetPosition == new Vector2(-100, -100) && State != PersonSTATE.Forrow)
        {
            //前のステートによって変える
            if (preState == PersonSTATE.Help)
            {
                State = PersonSTATE.Help;
            }
            if (preState == PersonSTATE.FloatPull)
            {
                State = PersonSTATE.FloatPull;
            }
            if (preState == PersonSTATE.Float)
            {
                State = PersonSTATE.Float;
            }
        }
        if (State == PersonSTATE.Approach)
        {
            direction = targetPosition - position;
        }
        else
        {
            speed = NormalSpeed;
        }
        if (State == PersonSTATE.FloatPull && Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
            speed = NormalSpeed;
        }
        if (State == PersonSTATE.FloatPull && Input.GetKeyUp(KeyCode.Space))
        {
            State = PersonSTATE.Float;
            preState = PersonSTATE.Float;
        }
        velocity = direction.normalized * speed;
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
                preState = PersonSTATE.Help;
            }
            isSharkCollision = false;
        }

    }

    //private void FixedUpdate()
    //{
    //    if (State == PersonSTATE.Forrow)
    //    {
    //        isCollisionFloatPull = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "FloatRing")
        //{
        //    //Debug.Log(collision.GetComponent<FloatRingScript>().GetState());
        //    if (collision.GetComponent<FloatRingScript>().GetState() == (int)FloatRingScript.STATE.False)
        //    {
        //        // ChangeSprite(sprite2);
        //        if (State == PersonSTATE.Help)
        //        {
        //            State = PersonSTATE.FloatPull;
        //            preState = State;
        //            targetPosition = new Vector2(-100, -100);
        //        }
        //    }
        //}
        if (collision.gameObject.tag == "Person")
        {
            //if (State == PersonSTATE.FloatPull && Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S) && collision.gameObject.GetComponent<PersonScript>().GetState() == (int)PersonSTATE.Float)
            //{
            //    collision.gameObject.GetComponent<PersonScript>().SetState(PersonSTATE.Forrow);
            //}
            if (collision.gameObject.GetComponent<PersonScript>().GetState() == (int)PersonSTATE.Float && State == PersonSTATE.Forrow)
            {
                collision.gameObject.GetComponent<PersonScript>().SetIsCollisionFloatPull(true);
            }
            if (collision.gameObject.GetComponent<PersonScript>().GetState() == (int)PersonSTATE.Float && State == PersonSTATE.FloatPull)
            {
                collision.gameObject.GetComponent<PersonScript>().SetIsCollisionFloatPull(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Person")
        {
            if (collision.gameObject.GetComponent<PersonScript>().GetState() == (int)PersonSTATE.Float && State == PersonSTATE.Forrow)
            {
                if (isCollisionFloatPull == false)
                {
                    collision.gameObject.GetComponent<PersonScript>().SetIsCollisionFloatPull(isCollisionFloatPull);
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Person")
        {
            if (collision.gameObject.GetComponent<PersonScript>().GetState() == (int)PersonSTATE.Forrow && State == PersonSTATE.Forrow)
            {
                collision.gameObject.GetComponent<PersonScript>().SetState(PersonSTATE.Float);
                collision.gameObject.GetComponent<PersonScript>().SetVelocity(Vector2.zero);
                isCollisionFloatPull = false;
                collision.gameObject.GetComponent<PersonScript>().SetIsCollisionFloatPull(false);
            }
        }
    }

    void ChangeSprite(Sprite newSprite)
    {
        // オブジェクトのスプライトを変更
        spriteRenderer.sprite = newSprite;
    }

    void SpriteState()
    {
        if (State == PersonSTATE.Help)
        {
            ChangeSprite(helpSprite);
        }
        if (State == PersonSTATE.Float)
        {
            ChangeSprite(floatSprite);
        }
        if (State == PersonSTATE.Approach)
        {
            ChangeSprite(ApproachSprite);
        }
        if (State == PersonSTATE.FloatPull)
        {
            ChangeSprite(floatPullSprite);
        }
        if (State == PersonSTATE.Forrow)
        {
            ChangeSprite(ForrowSprite);
        }
    }

    public void SetVelocity(Vector2 velocity) { this.velocity = velocity; }

    private void DestroySelf() { Destroy(this.gameObject); }

    public void SetIsSharkCollision(bool isSharkCollision) { this.isSharkCollision = isSharkCollision; }

    public void SetFalse() { State = PersonSTATE.False; }

    public void SetTargetPosition(Vector2 targetPosition) { this.targetPosition = targetPosition; }
    public int GetState() { return (int)State; }
    public void SetState(PersonSTATE state)
    {
        State = state;
        preState = State;
    }
    public void SetPosition(Vector2 position) { this.position = position; }

    public void SetIsCollisionFloatPull(bool isCollision) { this.isCollisionFloatPull = isCollision; }
    public bool GetIsCollisionFloatPull() { return this.isCollisionFloatPull; }
}