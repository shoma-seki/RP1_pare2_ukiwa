using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScript : MonoBehaviour
{
    private Vector2 position;
    private Vector2 velocity = new Vector2(-30, 0);

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position += velocity * Time.deltaTime;
        transform.position = position;
        if (position.x <= -20)
        {
            Destroy(this.gameObject);
        }
    }
}
