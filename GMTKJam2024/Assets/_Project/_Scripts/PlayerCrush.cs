using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCrush : MonoBehaviour
{
    private bool touchingSafe = false;
    private bool killable = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.activeWindow.application.activeLevel.ResetPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Safe"))
        {
            touchingSafe = true;
        }

        if (collision.gameObject.CompareTag("Kill") && killable)
            GameManager.Instance.activeWindow.application.activeLevel.ResetPlayer();
    }

    private void Update()
    {
        if (!touchingSafe)
        {
            killable = true;
        }
        else
        {
            killable = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Safe"))
        {
            touchingSafe = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Safe"))
        {
            touchingSafe = true;
        }

        if (collision.gameObject.CompareTag("Kill") && killable)
            GameManager.Instance.activeWindow.application.activeLevel.ResetPlayer();
    }
}
