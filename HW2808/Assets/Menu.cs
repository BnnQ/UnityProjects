using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameStateManager gameStateManager;

    void Start()
    {
        gameStateManager = ServiceContainer.GameStateManager;
    }
    
    public void StartGame()
    {
        gameStateManager.StartGame();
    }

    public void ExitGame()
    {
        gameStateManager.ExitGame();
    }
}
