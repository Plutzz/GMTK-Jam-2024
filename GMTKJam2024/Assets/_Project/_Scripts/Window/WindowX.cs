using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowX : MonoBehaviour
{
    private SpriteRenderer rend;
    [SerializeField] private bool applyOffset = true;
    [SerializeField] private bool onlyHide;
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
            transform.localPosition = new Vector3((rend.size.x / 2) + offset.x, (rend.size.y / 2) + offset.y, transform.localPosition.z);
    }

    private void OnMouseEnter()
    {
        GameManager.Instance.SetDefaultCursor();
    }

    private void OnMouseDown()
    {
        if(!onlyHide)
        {
            GetComponentInParent<DesktopWindow>().CloseWindow();
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
