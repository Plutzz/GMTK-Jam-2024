using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowX : MonoBehaviour
{
    private SpriteRenderer rend;
    [SerializeField] private bool applyOffset = true;
    [SerializeField] private Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(applyOffset)
            transform.localPosition = new Vector2(rend.size.x / 2, rend.size.y / 2) + offset;
    }

    private void OnMouseEnter()
    {
        GameManager.Instance.SetDefaultCursor();
    }

    private void OnMouseDown()
    {
        GetComponentInParent<DesktopWindow>().CloseWindow();
    }
}
