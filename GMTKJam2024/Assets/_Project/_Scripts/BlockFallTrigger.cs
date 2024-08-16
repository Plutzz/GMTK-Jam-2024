using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFallTrigger : MonoBehaviour
{
    [SerializeField] private int numLives = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Debug.Log(numLives + " Lives Remaining");
            numLives--;
            if(numLives <= 0)
            {
                Debug.Log("YOU LOSE");
            }
        }
    }
}
