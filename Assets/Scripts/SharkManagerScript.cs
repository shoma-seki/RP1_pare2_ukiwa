using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkManagerScript : MonoBehaviour
{
    [SerializeField] GameObject shark;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("PopEnemySet1", 5f, 60f);
        //InvokeRepeating("PopEnemySet2", 10f, 60f);
        //InvokeRepeating("PopEnemySet3", 15f, 60f);
        //InvokeRepeating("PopEnemySet4", 17f, 60f);
        //InvokeRepeating("PopEnemySet5", 20f, 60f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    //�K����ʊO�ŏo�����ƁI�I
    private void PopEnemySet1()
    {
        Instantiate(shark, new Vector2(-15, -0), Quaternion.identity);
        Instantiate(shark, new Vector2(-15, 4), Quaternion.identity);
        Instantiate(shark, new Vector2(15, -1), Quaternion.identity);
        Instantiate(shark, new Vector2(15, 3), Quaternion.identity);
    }

    private void PopEnemySet2()
    {
        Instantiate(shark, new Vector2(-15, -0), Quaternion.identity);
        Instantiate(shark, new Vector2(15, 4), Quaternion.identity);
    }
    private void PopEnemySet3()
    {
        Instantiate(shark, new Vector2(-15, -2), Quaternion.identity);
        Instantiate(shark, new Vector2(15, 1), Quaternion.identity);
    }
    private void PopEnemySet4()
    {
        Instantiate(shark, new Vector2(-15, 2), Quaternion.identity);
        Instantiate(shark, new Vector2(15, -1), Quaternion.identity);
    }
}
