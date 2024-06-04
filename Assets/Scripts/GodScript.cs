using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodScript : MonoBehaviour
{
    private float lerp = 0.1f;

    private Vector2 targetPosition;

    private GameObject ground;

    public bool isCombo;

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.FindWithTag("Ground");

        targetPosition = new Vector2(0, -10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        isCombo = ground.gameObject.GetComponent<GroundScript>().GetIsCombo();

        if (isCombo == true)
        {
            targetPosition = new Vector2(0, -5.5f);
        }
        else
        {
            targetPosition = new Vector2(0, -10.0f);
        }

        transform.position = Vector2.Lerp(transform.position, targetPosition, lerp);
    }
}
