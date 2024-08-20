using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontStepOnMe : MonoBehaviour
{
    [SerializeField] private Sprite pressedButtonSprite;
    [SerializeField] private SpriteRenderer rend;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !GameManager.Instance.darkModeEnabled)
        {
            rend.sprite = pressedButtonSprite;
            GameManager.Instance.ActivateDarkMode();
        }
    }
}
