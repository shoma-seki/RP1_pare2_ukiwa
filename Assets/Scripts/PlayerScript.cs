using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.VirtualTexturing;

public class PlayerScript : MonoBehaviour
{
    Vector2 position;
    private GameObject aim;

    [SerializeField] private GameObject floatRing;
    [SerializeField] private int floatRingCount;

    [SerializeField] private float kAddRingTime;
    private float addTime;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        aim = GameObject.FindWithTag("Aim");
        addTime = kAddRingTime;
    }

    // Update is called once per frame
    void Update()
    {
        addTime-= Time.deltaTime;
        if (addTime < 0)
        {
            addTime = kAddRingTime;
            floatRingCount++;
        }

        transform.position = position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (floatRingCount > 0)
            {
                floatRingCount--;
                Instantiate(floatRing, transform.position, Quaternion.identity);
            }
        }
    }

    public void SetPosition(float positionX) { position.x = positionX; }
    public void AddFloatRing() { floatRingCount++; }
    public int GetFloatRingCount() { return floatRingCount; }
}
