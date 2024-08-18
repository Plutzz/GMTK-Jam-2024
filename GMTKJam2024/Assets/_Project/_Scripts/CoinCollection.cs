using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Coin Enter");
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add to coins collected counter
            Destroy(gameObject);
        }
    }
}
