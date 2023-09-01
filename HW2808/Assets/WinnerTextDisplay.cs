using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinnerTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI WinnerText;
    
    private GameStateManager gameStateManager;
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = ServiceContainer.GameStateManager;
        
        OnGameStateChanged(gameStateManager.CurrentGameState);
        gameStateManager.GameStateChanged += OnGameStateChanged;
    }

    void OnDestroy()
    {
        gameStateManager.GameStateChanged -= OnGameStateChanged;
    }
    
    private void OnGameStateChanged(GameState gameState)
    {
        WinnerText.enabled = gameState == GameState.Finished;
    }
    
}
