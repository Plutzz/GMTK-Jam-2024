using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTest : MonoBehaviour
{
    private int initWidth;
    private int prevWidth;
    private void Start()
    {
        initWidth = Screen.width;
        prevWidth = Screen.width;
    }

    private void Update()
    {
        if (prevWidth != Screen.width)
        {
            Tween();
        }
        prevWidth = Screen.width;
    }

    private void Tween()
    {
        transform.DOKill();
        Debug.Log("Tween");
        transform.DOScale(initWidth / (float)Screen.width / 2f, 1f);
        //transform.DOScaleX(initWidth / (float)Screen.width, 1f);
        //transform.DOScaleY(initWidth / (float)Screen.width, 1f);

    }
}
