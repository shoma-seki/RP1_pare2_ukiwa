using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkManagerScript : MonoBehaviour
{
    [SerializeField] GameObject shark;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("PopEnemySet1", 5f, 5f);
        //InvokeRepeating("PopEnemySet2", 10f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    //必ず画面外で出すこと！！
    private void PopEnemySet1()
    {
        Instantiate(shark, new Vector2(-15, -3), Quaternion.identity);
        Instantiate(shark, new Vector2(15, 7), Quaternion.identity);
    }

    private void PopEnemySet2()
    {
        Instantiate(shark, new Vector2(15, -3), Quaternion.identity);
        Instantiate(shark, new Vector2(15, 0), Quaternion.identity);
    }
}
