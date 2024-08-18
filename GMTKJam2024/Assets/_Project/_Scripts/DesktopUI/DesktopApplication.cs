using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopApplication : MonoBehaviour
{
    [SerializeField] private string applicationName;
    [SerializeField] private GameObject applicationWindow;
    [SerializeField] private Vector3 playerStartPos;
    public void StartApplication()
    {
        Debug.Log(applicationName);
        Instantiate(applicationWindow);
        AudioManager.Instance.PlaySound(AudioManager.Sounds.blip2);
    }
}
