using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCenter : MonoBehaviour
{
    private SpriteRenderer rend;
    private BoxCollider2D col;
    private Vector2 enterSize;
    private Vector3 scaleOther;
    [SerializeField] private float borderSize;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentInParent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //col.size = new Vector3(rend.size.x - borderSize, rend.size.y - borderSize);
        transform.localScale = new Vector3(rend.size.x, rend.size.y, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerEnter");
            enterSize = new Vector3(rend.size.x - borderSize, rend.size.y - borderSize);
            scaleOther = collision.transform.localScale;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerStay");
            //collision.transform.localScale = new Vector2(enterSize.y / col.size.y, enterSize.x / col.size.x);
            collision.transform.localScale = new Vector2((rend.size.y - borderSize) / enterSize.y * scaleOther.x, (rend.size.y - borderSize) / enterSize.y * scaleOther.y);
        }
    }


}
