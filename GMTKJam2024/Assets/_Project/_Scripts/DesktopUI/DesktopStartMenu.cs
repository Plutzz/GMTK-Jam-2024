using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopStartMenu : MonoBehaviour
{
    public void FlipActiveState()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

}
