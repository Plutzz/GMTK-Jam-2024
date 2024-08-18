using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCoin : MonoBehaviour
{
    [SerializeField] private int coinAmount;
    [SerializeField] private int startCoinId;
    [SerializeField] private Sprite collected;
    [SerializeField] private Sprite notCollected;

    [SerializeField]private List<GameObject> coinList = new List<GameObject>();
    // Start is called before the first frame update
    
    private void OnEnable()
    {
        for(int i = startCoinId; i < coinAmount+startCoinId; i++)
        {
            if (GameManager.Instance.coinCollector.collectedCoins[i]) { coinList[i - startCoinId].GetComponent<SpriteRenderer>().sprite = collected; }
            
            else { coinList[i - startCoinId].GetComponent<SpriteRenderer>().sprite = notCollected; }
        }
    }
}
