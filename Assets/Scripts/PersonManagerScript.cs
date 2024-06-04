using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonManagerScript : MonoBehaviour
{
    [SerializeField] GameObject person;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PopPersonSet1", 5f, 5f);
        InvokeRepeating("PopPersonSet2", 10f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void PopPersonSet1()
    {
        Instantiate(person, new Vector2(-13, -3), Quaternion.identity);
        Instantiate(person, new Vector2(13, 7), Quaternion.identity);
    }

    private void PopPersonSet2()
    {
        Instantiate(person, new Vector2(10, -3), Quaternion.identity);
        Instantiate(person, new Vector2(7, 0), Quaternion.identity);
    }
}
