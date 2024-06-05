using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonManagerScript : MonoBehaviour
{
    [SerializeField] GameObject person;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PopPersonSet3", 10f, 13f);
        InvokeRepeating("PopPersonSet6", 12f, 13f);
        InvokeRepeating("PopPersonSet1", 1f, 60f);
        InvokeRepeating("PopPersonSet1_1", 2f, 60f);
        InvokeRepeating("PopPersonSet2", 15f, 60f);

        InvokeRepeating("PopPersonSet4", 21, 60f);
        InvokeRepeating("PopPersonSet4_1", 22f, 60f);
        InvokeRepeating("PopPersonSet5", 35f, 60f);

        InvokeRepeating("PopPersonSet1", 41f, 60f);
        InvokeRepeating("PopPersonSet1_1", 42f, 60f);
        InvokeRepeating("PopPersonSet2", 55f, 60f);
        InvokeRepeating("PopPersonSet5", 55f, 60f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void PopPersonSet1()
    {
        Instantiate(person, new Vector2(-8.96f, 4.88f), Quaternion.identity);
        Instantiate(person, new Vector2(-7.63f, 0.26f), Quaternion.identity);
        Instantiate(person, new Vector2(-7f, -2.26f), Quaternion.identity);
    }

    private void PopPersonSet1_1()
    {
        Instantiate(person, new Vector2(0.96f, 2.88f), Quaternion.identity);
        Instantiate(person, new Vector2(4.63f, 1.26f), Quaternion.identity);
        Instantiate(person, new Vector2(6f, -0.26f), Quaternion.identity);
    }

    private void PopPersonSet2()
    {
        Instantiate(person, new Vector2(0, 5), Quaternion.identity);
        Instantiate(person, new Vector2(0.1f, 2), Quaternion.identity);
        Instantiate(person, new Vector2(0.1f, -2), Quaternion.identity);
        Instantiate(person, new Vector2(-0.05f, -3), Quaternion.identity);
    }

    private void PopPersonSet3()
    {
        Instantiate(person, new Vector2(-10, 6), Quaternion.identity);
        Instantiate(person, new Vector2(-3.4f, 6.5f), Quaternion.identity);
        Instantiate(person, new Vector2(4, 5.8f), Quaternion.identity);
        Instantiate(person, new Vector2(10, 5.4f), Quaternion.identity);
    }



    private void PopPersonSet4()
    {
        Instantiate(person, new Vector2(-3.96f, 4.88f), Quaternion.identity);
        Instantiate(person, new Vector2(-4.63f, 0.26f), Quaternion.identity);
        Instantiate(person, new Vector2(-4f, -2.26f), Quaternion.identity);
    }

    private void PopPersonSet4_1()
    {
        Instantiate(person, new Vector2(-2.96f, 2.88f), Quaternion.identity);
        Instantiate(person, new Vector2(-4.63f, 1.26f), Quaternion.identity);
        Instantiate(person, new Vector2(-6f, -0.26f), Quaternion.identity);
    }

    private void PopPersonSet5()
    {
        Instantiate(person, new Vector2(0, 5), Quaternion.identity);
        Instantiate(person, new Vector2(0.1f, 2), Quaternion.identity);
        Instantiate(person, new Vector2(0.1f, -2), Quaternion.identity);
        Instantiate(person, new Vector2(-0.05f, -3), Quaternion.identity);
    }

    private void PopPersonSet6()
    {
        Instantiate(person, new Vector2(-10, -3.0f), Quaternion.identity);
        Instantiate(person, new Vector2(-3.4f, -3.5f), Quaternion.identity);
        Instantiate(person, new Vector2(4, -2.8f), Quaternion.identity);
        Instantiate(person, new Vector2(10, -2.4f), Quaternion.identity);
    }
}
