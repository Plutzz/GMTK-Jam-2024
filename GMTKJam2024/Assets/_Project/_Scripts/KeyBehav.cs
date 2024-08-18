using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehav : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.gameObject.tag.Equals("Player"))) { return; }
        gameObject.SetActive(false);
        door.SetActive(false);
    }
    public void ResetKey()
    {
        door.SetActive(true);
        gameObject.SetActive(true);
    }
}
