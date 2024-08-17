using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSize : MonoBehaviour
{
    [SerializeField] private bool rightScaleX, leftScaleX, scaleY;
    private SpriteRenderer rend;
    private BoxCollider2D col;
    private Vector3 mousePosition;
    private bool dragging;
    private void Awake()
    {
        rend = GetComponentInParent<SpriteRenderer>();
        col = GetComponentInParent<BoxCollider2D>();
    }

    private void Update()
    {
        if(rightScaleX && !dragging)
        {
            transform.position = transform.parent.position + Vector3.right * rend.size.x / 2;
            col.size = new Vector2(col.size.x, rend.size.y);
        }
        if(leftScaleX && !dragging)
        {
            transform.position = transform.parent.position + Vector3.left * rend.size.x / 2;
            col.size = new Vector2(col.size.x, rend.size.y);
        }
        if(scaleY && !dragging)
        {
            transform.position = transform.parent.position + Vector3.down * rend.size.y / 2;
            col.size = new Vector2(rend.size.x, col.size.y);
        }
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        dragging = true;
    }
    private void OnMouseUp()
    {
        dragging = false;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        if(rightScaleX || leftScaleX)
        {
            transform.position = new Vector3(mousePos.x, transform.position.y);
            rend.size = new Vector2((transform.parent.position.x - mousePos.x) * -2, rend.size.y);
            if(rend.size.x < 0.25f)
            {
                rend.size = new Vector2(0.25f, rend.size.y);
            }
        }
        if(scaleY)
        {
            transform.position = new Vector3(transform.position.x, mousePos.y);
            rend.size = new Vector2(rend.size.x, (transform.parent.position.y - mousePos.y) * 2);
            if (rend.size.y < 0.25f)
            {
                rend.size = new Vector2(rend.size.x, 0.25f);
            }
        }
       
    }
}
