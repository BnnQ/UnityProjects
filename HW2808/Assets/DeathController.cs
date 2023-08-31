using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    private CoinService coinService;

    void Start()
    {
        coinService = ServiceContainer.CoinService;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            coinService.ResetCoins();
            SceneManager.LoadScene(SceneManager.GetActiveScene()
                .buildIndex);
        }
    }
}
