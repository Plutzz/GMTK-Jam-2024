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
    public bool dragging;
    [SerializeField] Vector2 initWindowSize;
    [SerializeField] private float lerpSpeed = .1f;
    public float minXSize = 0.25f, minYSize = 0.25f, maxXSize = 17.7f, maxYSize = 5f, horizontalBounds = 9.5f, topBound = 4.9f, bottomBound = -3f;
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

        if (applicationWindow && !dragging && GameManager.Instance.player != null)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, GameManager.Instance.player.transform.position.x, lerpSpeed), Mathf.Lerp(transform.position.y, GameManager.Instance.player.transform.position.y, lerpSpeed));

            float _leftBound = transform.position.x - (rend.size.x / 2);
            if(_leftBound < -horizontalBounds)
            {
                //transform.position = new Vector2(Mathf.Lerp(transform.position.x, -horizontalBounds + (rend.size.x / 2), borderLerpSpeed), transform.position.y);
                transform.position = new Vector2(-horizontalBounds + (rend.size.x / 2), transform.position.y);
            }
            float _rightBound = transform.position.x + (rend.size.x / 2);
            if (_rightBound > horizontalBounds)
            {
                //transform.position = new Vector2(Mathf.Lerp(transform.position.x, horizontalBounds - (rend.size.x / 2), borderLerpSpeed), transform.position.y);
                transform.position = new Vector2(horizontalBounds - (rend.size.x / 2), transform.position.y);
            }

            float _topBound = transform.position.y + (rend.size.y / 2);
            if (_topBound > topBound)
            {
                //transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, verticalBounds - (rend.size.y / 2), borderLerpSpeed));
                transform.position = new Vector2(transform.position.x, topBound - (rend.size.y / 2));
            }
            float _bottomBound = transform.position.y - (rend.size.y / 2);
            if (_bottomBound < bottomBound)
            {
                //transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, -verticalBounds + (rend.size.y / 2), lerpSpeed));
                transform.position = new Vector2(transform.position.x, bottomBound + (rend.size.y / 2));
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
