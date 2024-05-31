using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersinScript : MonoBehaviour
{
    public Sprite sprite1; // 新しいスプライト1
    public Sprite sprite2; // 新しいスプライト2

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FloatRing")
        {
            ChangeSprite(sprite2);
        }
    }

    void ChangeSprite(Sprite newSprite)
    {
        // オブジェクトのスプライトを変更
        spriteRenderer.sprite = newSprite;
    }
}
