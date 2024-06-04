using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private GameObject[] person;
    private GameObject[] floatRings;
    private GameObject player;

    private Vector2 pos0;
    private Vector2 pos1;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        person = GameObject.FindGameObjectsWithTag("Person");
        floatRings = GameObject.FindGameObjectsWithTag("FloatRing");
        player = GameObject.FindWithTag("Player");
        foreach (GameObject f in floatRings)
        {
            if (f.gameObject.GetComponent<FloatRingScript>().GetState() == (int)FloatRingScript.STATE.Push)
            {
                pos0 = f.transform.position;
                lineRenderer.SetPosition(0, pos0);
                lineRenderer.SetPosition(1, pos1);
            }
        }

        foreach (GameObject p in person)
        {
            if (p.gameObject.GetComponent<PersonScript>().GetState() == (int)PersonScript.PersonSTATE.FloatPull)
            {
                pos0 = p.transform.position;
                lineRenderer.SetPosition(0, pos0);
                lineRenderer.SetPosition(1, pos1);
            }
        }
        pos1 = player.transform.position;

        if (Input.GetKey(KeyCode.Space) == false)
        {
            pos0 = new Vector2(0, -10);
            lineRenderer.SetPosition(0, pos0);
            lineRenderer.SetPosition(1, pos1);
        }
    }
}
