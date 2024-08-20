using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontStepOnMe : MonoBehaviour
{
    [SerializeField] private Sprite pressedButtonSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !GameManager.Instance.darkModeEnabled)
        {
            GameManager.Instance.ActivateDarkMode();
        }
    }
}
