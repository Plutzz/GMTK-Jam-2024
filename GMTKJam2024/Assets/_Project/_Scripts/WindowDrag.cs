using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindowDrag : MonoBehaviour
{
    private Vector3 mousePosition;
    private bool dragging;
    private BoxCollider2D col;
    private SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponentInParent<SpriteRenderer>();
        col = GetComponentInParent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!dragging)
        {
            transform.position = transform.parent.position + Vector3.up * rend.size.y / 2;
            col.size = new Vector2(rend.size.x, col.size.y);
        }
    }
    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.parent.position);
        dragging = true;
    }
    private void OnMouseUp()
    {
        dragging = false;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        transform.parent.position = new Vector3(mousePos.x, mousePos.y);
    }
}