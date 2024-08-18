using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopWindow : MonoBehaviour
{
    public DesktopApplication application;
    private SpriteRenderer rend;
    [SerializeField] Vector2 initWindowSize;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.size = initWindowSize;
    }

    public void CloseWindow()
    {
        if(application != null)
        {
            application.CloseApplication();
        }

        Destroy(gameObject);
    }

    public void ResizeWindow(Vector2 _size)
    {
        rend.size = _size;
    }


}
