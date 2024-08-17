using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScaleTest : MonoBehaviour
{
    private int initWidth;
    private int prevWidth;
    private int initHeight;
    private int prevHeight;
    private float initXScale;
    private float initYScale;
    private Vector3 prevTruePos;
    public bool ScaleDefault;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        Screen.SetResolution(800, 450, false);
    }
    private void Start()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 truePos = new Vector3(Screen.mainWindowPosition.x + screenPos.x, Screen.mainWindowPosition.y + Screen.height - screenPos.y, screenPos.z);
        prevTruePos = truePos;


        initWidth = Screen.width;
        prevWidth = Screen.width;
        initHeight = Screen.height;
        prevHeight = Screen.height;
        initXScale = transform.localScale.x;
        initYScale = transform.localScale.y;
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.L))
        //{
        //    Screen.SetResolution(Screen.width + 16, Screen.height + 9, false);
        //    //BorderlessWindow.MoveWindowPos(Screen.width + 16, Screen.height + 9);
        //}
        //if (Input.GetKey(KeyCode.K))
        //{
        //    Screen.SetResolution(Screen.width - 16, Screen.height - 9, false);
        //    //BorderlessWindow.MoveWindowPos(Screen.width - 16, Screen.height - 9);
        //}
        if(text != null)    
            text.text = Screen.width + ":" + Screen.height;

        if (prevWidth != Screen.width || prevHeight != Screen.height)
        {
            if (ScaleDefault)
                Scale();
            else
                OtherScale();
        }

        if (!ScaleDefault)
        {
            Debug.Log("Screen" + Camera.main.WorldToScreenPoint(transform.position));
            CalculatePosition();
        }

        prevWidth = Screen.width;
        prevHeight = Screen.height;

        




    }

    private void Scale()
    {
        Debug.Log("Tween");
        transform.localScale = new Vector3(initXScale * initHeight / (float)Screen.height, initYScale * initWidth / (float)Screen.width, 1);
    }

    private void OtherScale()
    {
        transform.localScale = new Vector3(initXScale * initHeight / (float)Screen.height, initYScale * initHeight / (float)Screen.height, 1);
    }

    private void CalculatePosition()
    {
        //Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 truePos = new Vector3(Screen.mainWindowPosition.x + screenPos.x, Screen.mainWindowPosition.y + Screen.height - screenPos.y, screenPos.z);

        if(prevTruePos.x != truePos.x || prevTruePos.y != truePos.y)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(prevTruePos.x - Screen.mainWindowPosition.x,
                -prevTruePos.y + Screen.mainWindowPosition.y + prevHeight, screenPos.z));
        }
        //prevTruePos = truePos;
        Debug.Log("True Pos " + truePos);
        // IF OBJ IS BELOW ORIGIN
        // y position - distance below center (pixel) / y scale
    }
}
