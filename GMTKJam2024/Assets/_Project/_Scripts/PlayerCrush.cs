using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCrush : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.GetComponent<BoxCollider2D>() == collision.otherCollider) 
          GameManager.Instance.activeWindow.application.activeLevel.ResetPlayer();
        
    }
}
