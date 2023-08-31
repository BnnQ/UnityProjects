using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinService
{
    private int coinCount;

    public event Action<int> CoinCountChanged; 

    public CoinService()
    {
        coinCount = 0;
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        CoinCountChanged?.Invoke(coinCount);
    }

    public int GetCoinCount()
    {
        return coinCount;
    }
    
    public void ResetCoins()
    {
        coinCount = 0;
        CoinCountChanged?.Invoke(coinCount);
    }
    
}
