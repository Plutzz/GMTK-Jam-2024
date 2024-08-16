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
    [SerializeField] private TextMeshProUGUI text;
    private void Start()
    {
        //BorderlessWindow.SetFramelessWindow();
        //BorderlessWindow.MoveWindowPos(1600, 900);
        initWidth = Screen.width;
        prevWidth = Screen.width;
        initHeight = Screen.height;
        prevHeight = Screen.height;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            Screen.SetResolution(Screen.width + 16, Screen.height + 9, false);
            //BorderlessWindow.MoveWindowPos(Screen.width + 16, Screen.height + 9);
        }
        if (Input.GetKey(KeyCode.K))
        {
            Screen.SetResolution(Screen.width - 16, Screen.height - 9, false);
            //BorderlessWindow.MoveWindowPos(Screen.width - 16, Screen.height - 9);
        }

        text.text = Screen.width + ":" + Screen.height;

        if (prevWidth != Screen.width || prevHeight != Screen.height)
        {
            Tween();
        }
        prevWidth = Screen.width;
        prevHeight = Screen.height;


    }

    private void Tween()
    {
        //transform.DOKill();
        Debug.Log("Tween");
        //transform.DOScaleX(initXWidth / (float)Screen.width, 1f);
        //transform.DOScaleY(initYWidth / (float)Screen.height, 1f);
        transform.localScale = new Vector3(initWidth / (float)Screen.width, initHeight / (float)Screen.height, 1);
    }
}
