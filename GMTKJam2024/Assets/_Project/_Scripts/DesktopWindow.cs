using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopWindow : MonoBehaviour
{
    [SerializeField] private bool applicationWindow; // Check if this is an application window to properly set the GameManager.Instance.activeWindow;
    public DesktopApplication application;
    public SpriteRenderer rend;
    public float borderSize;
    [SerializeField] Vector2 initWindowSize;
    public float minXSize = 0.25f, minYSize = 0.25f, maxXSize = 17.7f, maxYSize = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rend.size = initWindowSize;
        if(applicationWindow)
        {
            GameManager.Instance.activeWindow = this;
        }
        
    }

    public void CloseWindow()
    {
        if(application != null)
        {
            application.CloseApplication();
        }
        GameManager.Instance.SetDefaultCursor();
        Destroy(gameObject);
    }

    public void ResizeWindow(Vector2 _size)
    {
        rend.size = _size;
    }


}
