using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    [SerializeField] private GameObject computerAmbience;
    // Song must be a child of music manager
    public void PlaySong(GameObject song)
    {
        DisableAllChildren();
        song.SetActive(true);
    }

    public void PlayAmbience()
    {
        DisableAllChildren();
        computerAmbience.SetActive(true);
    }

    private void DisableAllChildren()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

}
