using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSize : MonoBehaviour, IWindowHandle
{
    [SerializeField] private bool rightScaleX, leftScaleX, scaleY;
    [SerializeField] private Texture2D cursor;
    [SerializeField] private DesktopWindow window;
    private SpriteRenderer rend;
    private BoxCollider2D col;
    private Vector3 mousePosition;
    private Vector3 initialRendSize;
    private bool dragging;
    private bool needToReset;
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
        initialRendSize = rend.size;
        dragging = true;
        needToReset = false;
    }
    private void OnMouseUp()
    {
        dragging = false;
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.one * 16, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        GameManager.Instance.SetDefaultCursor();
    }

    private void OnMouseDrag()
    {
        if (needToReset) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        if(rightScaleX)
        {
            transform.position = new Vector3(mousePos.x, transform.position.y);
            rend.size = new Vector2((transform.parent.position.x - mousePos.x) * -2, (transform.parent.position.y - mousePos.y + (initialRendSize.y / 2)) * 2);
        }
        if (leftScaleX)
        {
            Debug.Log(mousePos.y);
            transform.position = new Vector3(mousePos.x, transform.position.y);
            rend.size = new Vector2((transform.parent.position.x - mousePos.x) * 2, (transform.parent.position.y - mousePos.y + (initialRendSize.y / 2)) * 2);
     
        }
        if (scaleY)
        {
            transform.position = new Vector3(transform.position.x, mousePos.y);
            rend.size = new Vector2((transform.parent.position.x - mousePos.x + (initialRendSize.x / 2)) * 2, (transform.parent.position.y - mousePos.y) * 2);
        }

        if (rend.size.x < window.minXSize)
        {
            rend.size = new Vector2(window.minXSize, rend.size.y);
        }
        if (rend.size.x > window.maxXSize)
        {
            rend.size = new Vector2(window.maxXSize, rend.size.y);
        }

        if (rend.size.y < window.minYSize)
        {
            rend.size = new Vector2(rend.size.x, window.minYSize);
        }
        if (rend.size.y > window.maxYSize)
        {
            rend.size = new Vector2(rend.size.x, window.maxYSize);
        }

    }
    public void ForceReset()
    {
        needToReset = true;
    }
}
