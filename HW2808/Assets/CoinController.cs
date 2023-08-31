using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private CoinService coinService;

    void Start()
    {
        coinService = ServiceContainer.CoinService;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinService.AddCoins(1);
            Destroy(other.gameObject);
        }
    }
    
}
