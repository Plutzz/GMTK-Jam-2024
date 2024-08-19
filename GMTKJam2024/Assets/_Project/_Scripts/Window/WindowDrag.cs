using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindowDrag : MonoBehaviour, IWindowHandle
{
    private Vector3 mousePosition;
    private bool dragging;
    private BoxCollider2D col;
    private SpriteRenderer rend;
    private bool needToReset;
    private DesktopWindow window;
    [SerializeField] private Texture2D hoverCursor, grabCursor;

    private void Start()
    {
        rend = GetComponentInParent<SpriteRenderer>();
        col = GetComponentInParent<BoxCollider2D>();
        window = GetComponentInParent<DesktopWindow>();
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
        Cursor.SetCursor(grabCursor, Vector2.one * 16, CursorMode.Auto);
        mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.parent.position);
        dragging = true;
        window.dragging = true;
        needToReset = false;
    }
    private void OnMouseUp()
    {
        dragging = false;
        window.dragging = false;
        Cursor.SetCursor(hoverCursor, Vector2.one * 16, CursorMode.Auto);
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(hoverCursor, Vector2.one * 16, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        GameManager.Instance.SetDefaultCursor();
    }

    private void OnMouseDrag()
    {
        if (needToReset) return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        transform.parent.position = new Vector3(mousePos.x, mousePos.y);
    }

    public void ForceReset()
    {
        needToReset = true;
    }
}