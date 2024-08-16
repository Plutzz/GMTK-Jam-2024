using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFallTrigger : MonoBehaviour
{
    [SerializeField] private int numLives = 3;
    public GameObject ground;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Debug.Log(numLives + " Lives Remaining");
            numLives--;
            Destroy(collision.gameObject);
            if(numLives <= 0)
            {
                Debug.Log("YOU LOSE");
                Destroy(ground);
            }
        }
    }
}
