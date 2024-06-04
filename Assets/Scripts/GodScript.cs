using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodScript : MonoBehaviour
{
    private float lerp = 0.1f;

    private Vector2 targetPosition;

    private bool isAppear;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector2(0, -10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAppear == true)
        {
            targetPosition = new Vector2(0, -5.5f);
        }
        else
        {
            targetPosition = new Vector2(0, -10.0f);
        }

        transform.position = Vector2.Lerp(transform.position, targetPosition, lerp);
    }

    public void SetIsAppear(bool isAppear) { this.isAppear = isAppear; }
}
