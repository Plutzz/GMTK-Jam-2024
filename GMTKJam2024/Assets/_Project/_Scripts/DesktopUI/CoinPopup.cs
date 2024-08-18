using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPopup : MonoBehaviour
{
    [SerializeField] private Vector3 popupPosition;
    private Vector3 initialPosition;
    [SerializeField] private Ease easeIn, easeOut;
    [SerializeField] private float popupTime;
    [SerializeField] private float waitDuration;
    [SerializeField] private TextMeshProUGUI coinText;


    public void Start()
    {
        initialPosition = transform.localPosition;
        GameManager.Instance.coinPopup = this;
    }

    public void DoPopup()
    {
        coinText.text = GameManager.Instance.CoinsCollected + "/" + GameManager.Instance.TotalCoins;
        transform.DOLocalMove(popupPosition, popupTime).SetEase(easeIn);
        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitDuration);
        transform.DOLocalMove(initialPosition, popupTime).SetEase(easeOut);
    }
}
