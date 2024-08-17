using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationIcon : MonoBehaviour
{
    [SerializeField] private GameObject highlight;
    [SerializeField] private DesktopApplication application;

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        application.StartApplication();
    }


}
