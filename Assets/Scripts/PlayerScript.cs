using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.VirtualTexturing;

public class PlayerScript : MonoBehaviour
{
    Vector2 position;
    private GameObject aim;

    [SerializeField] private GameObject floatRing;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        aim = GameObject.FindWithTag("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(floatRing, transform.position, Quaternion.identity);
        }
    }

    public void SetPosition(float positionX) { position.x = positionX; }
}
