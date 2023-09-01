using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState : byte
{
    NotStarted,
    Started,
    Finished
}

public class GameStateManager
{
    private GameState currentGameState = GameState.NotStarted;
    public GameState CurrentGameState
    {
        get => currentGameState;
        private set
        {
            currentGameState = value;
            GameStateChanged?.Invoke(value);
        }
    }
    public event Action<GameState> GameStateChanged;
    
    private CoinService coinService;
    public GameStateManager()
    {
        coinService = ServiceContainer.CoinService;
    }

    public void StartGame()
    {
        CurrentGameState = GameState.Started;
        coinService.ResetCoins();
        SceneManager.LoadScene("FirstLevel");
    }

    public void FinishGame()
    {
        CurrentGameState = GameState.Finished;
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
