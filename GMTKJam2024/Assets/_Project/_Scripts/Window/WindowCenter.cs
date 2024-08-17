using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCenter : MonoBehaviour
{
    private SpriteRenderer rend;
    [SerializeField] private SpriteRenderer background;
    private BoxCollider2D col;
    private Vector2 enterSize;
    private Vector3 scaleOther;
    [SerializeField] private float borderSize;
    [SerializeField] private bool scaleEffect;
    // Start is called before the first frame update
    void Start()
    {
        rend = transform.parent.GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //col.size = new Vector3(rend.size.x - borderSize, rend.size.y - borderSize);
        transform.localScale = new Vector3(rend.size.x, rend.size.y, 1f);
        if(background != null)
        {
            background.size = new Vector2(rend.size.x, rend.size.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scale") && scaleEffect)
        {
            Debug.Log("PlayerEnter");
            enterSize = new Vector3(rend.size.x - borderSize, rend.size.y - borderSize);
            scaleOther = collision.transform.localScale;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scale") && scaleEffect)
        {
            Debug.Log("PlayerStay");
            //collision.transform.localScale = new Vector2(enterSize.y / col.size.y, enterSize.x / col.size.x);
            collision.transform.localScale = new Vector2((rend.size.y - borderSize) / enterSize.y * scaleOther.x, (rend.size.y - borderSize) / enterSize.y * scaleOther.y);
        }
    }


}
