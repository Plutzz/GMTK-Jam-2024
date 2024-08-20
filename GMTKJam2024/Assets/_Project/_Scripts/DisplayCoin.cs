using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCoin : MonoBehaviour
{
    [SerializeField] private int coinAmount;
    [SerializeField] private int startCoinId;
    [SerializeField] private Sprite collected;
    [SerializeField] private Sprite notCollected;
    [SerializeField] private TextMeshPro gemText;

    [SerializeField] private Sprite upgradeButtonReady;
    [SerializeField] private Image upgradeButton;
    private bool upgradeReady = true;

    [Header("End Game")]
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private Animation glitchEffect;

    [SerializeField]private List<GameObject> coinList = new List<GameObject>();
    // Start is called before the first frame update
    
    private void OnEnable()
    {
        int numCoinsCollected = 0;

        for(int i = startCoinId; i < coinAmount+startCoinId; i++)
        {
            if (GameManager.Instance.coinCollector.collectedCoins[i])
            { 
                coinList[i - startCoinId].GetComponent<SpriteRenderer>().sprite = collected; 
                numCoinsCollected++;
            }
            
            else { coinList[i - startCoinId].GetComponent<SpriteRenderer>().sprite = notCollected; }

            
        }

        gemText.text = numCoinsCollected + "";

        if(numCoinsCollected == coinAmount)
        {
            upgradeButton.sprite = upgradeButtonReady;
            upgradeReady = true;
        }
    }


    public void TryUpgrade()
    {
        if(upgradeReady)
        {
            AudioManager.Instance.PlayEntireSound(AudioManager.Sounds.endSequence);
            blackScreen.SetActive(true);
            glitchEffect.Play();
            StartCoroutine(Wait());
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(4.75f);
        blackScreen.SetActive(false);
        endScreen.SetActive(true);
    }
}
