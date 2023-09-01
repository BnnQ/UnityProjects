using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    private GameStateManager gameStateManager;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameStateManager.FinishGame();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = ServiceContainer.GameStateManager;
    }

}
