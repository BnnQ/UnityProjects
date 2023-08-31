using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{ 
    public TextMeshProUGUI CoinText;

    private CoinService coinService;
    
    // Start is called before the first frame update
    void Start()
    {
        coinService = ServiceContainer.CoinService;
        OnCoinCountChanged(coinService.GetCoinCount());
        coinService.CoinCountChanged += OnCoinCountChanged;
    }

    void OnDestroy()
    {
        coinService.CoinCountChanged -= OnCoinCountChanged;
    }

    private void OnCoinCountChanged(int coinCount)
    {
        CoinText.text = coinCount.ToString();
    }
    
}
