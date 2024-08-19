using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehav : MonoBehaviour
{
    [SerializeField] private GameObject[] doors;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.gameObject.tag.Equals("Player"))) { return; }
        gameObject.SetActive(false);
        AudioManager.Instance?.PlaySound(AudioManager.Sounds.pickupCoin2);
        foreach(GameObject door in doors)
        {
            door.SetActive(false);
        }
        
    }
    public void ResetKey()
    {
        Debug.Log("ResetKey");
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
        }
        gameObject.SetActive(true);
    }
}
