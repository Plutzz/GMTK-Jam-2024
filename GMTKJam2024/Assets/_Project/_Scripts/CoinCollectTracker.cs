using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectTracker
{
    public bool[] collectedCoins;

  
    public CoinCollectTracker (int totalCoins)
    {
        collectedCoins = new bool[totalCoins];
    }
    public void CoinActive(int id_)
    {
        collectedCoins[id_] = true;
        Debug.Log("This Coin Was Collected" +  id_);
    }
}
