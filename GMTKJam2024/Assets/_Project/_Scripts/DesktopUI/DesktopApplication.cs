using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopApplication : MonoBehaviour
{
    [SerializeField] private string applicationName;
    [SerializeField] private GameObject applicationWindow;
    public void StartApplication()
    {
        Debug.Log(applicationName);
        Instantiate(applicationWindow);
    }
}
