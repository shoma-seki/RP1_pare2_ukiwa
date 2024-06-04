using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class FloatRingCountManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject floatRing;
    private GameObject player;

    private int ringCount;
    private int preRingCount;

    public Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ringCount = player.gameObject.GetComponent<PlayerScript>().GetFloatRingCount();
        Debug.Log("ringCount" + ringCount);
        if (preRingCount != ringCount)
        {
            GameObject[] floatRings = GameObject.FindGameObjectsWithTag("FloatRingCount");
            foreach (GameObject r in floatRings)
            {
                Destroy(r.gameObject);
            }

            for (int i = 0; i < ringCount; i++)
            {
                Instantiate(floatRing, new Vector2(offset.x + (float)i / 1.5f, offset.y), Quaternion.identity);
            }
        }
        preRingCount = ringCount;
        Debug.Log("preringCount" + preRingCount);
    }
}
