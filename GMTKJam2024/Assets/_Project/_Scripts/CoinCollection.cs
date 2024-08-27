using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour, IResetable
{
    [SerializeField] private int coinId;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject filledGem, emptyGem;
    

    public void ResetObject()
    {
        if (GameManager.Instance.coinCollector.collectedCoins[coinId])
        {
            filledGem.SetActive(false);
            emptyGem.SetActive(true);
        }
        else
        {
            filledGem.SetActive(true);
            emptyGem.SetActive(false);
        }

        gameObject.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log("Coin Enter");
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add to coins collected counter
            AudioManager.Instance.PlaySound(AudioManager.Sounds.pickupCoin1);
            if (!GameManager.Instance.coinCollector.collectedCoins[coinId])
            {
                //anim.runtimeAnimatorController = emptyGem;
                GameManager.Instance.CollectCoin();
                GameManager.Instance.coinCollector.CoinActive(coinId);
            }
            gameObject.SetActive(false);
        }
    }
}
