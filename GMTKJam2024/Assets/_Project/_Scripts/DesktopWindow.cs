using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DesktopWindow : MonoBehaviour
{
    [SerializeField] private bool applicationWindow; // Check if this is an application window to properly set the GameManager.Instance.activeWindow;
    public DesktopApplication application;
    public SpriteRenderer rend;
    public float borderSize;
    [SerializeField] Vector2 initWindowSize;
    public float minXSize = 0.25f, minYSize = 0.25f, maxXSize = 17.7f, maxYSize = 5f, horizontalBounds = 9.5f, verticalBounds = 5.4f;
    // Start is called before the first frame update
    void Start()
    {
        rend.size = initWindowSize;
        if(applicationWindow)
        {
            GameManager.Instance.activeWindow = this;
        }
        
    }

    private void Update()
    {

        if (applicationWindow && GameManager.Instance.player != null)
        {
            transform.position = GameManager.Instance.player.transform.position;

            float _leftBound = transform.position.x - (rend.size.x / 2);
            if(_leftBound < -horizontalBounds)
            {
                transform.position = new Vector2(-horizontalBounds + (rend.size.x / 2), transform.position.y);
            }
            float _rightBound = transform.position.x + (rend.size.x / 2);
            if (_rightBound > horizontalBounds)
            {
                transform.position = new Vector2(horizontalBounds - (rend.size.x / 2), transform.position.y);
            }

            float _topBound = transform.position.y + (rend.size.y / 2);
            if (_topBound > verticalBounds)
            {
                transform.position = new Vector2(transform.position.x, verticalBounds - (rend.size.y / 2));
            }
            float _bottomBound = transform.position.y - (rend.size.y / 2);
            if (_bottomBound < -verticalBounds)
            {
                transform.position = new Vector2(transform.position.x, -verticalBounds + (rend.size.y / 2));
            }
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
