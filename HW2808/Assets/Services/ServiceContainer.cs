using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public static class ServiceContainer
{
    [CanBeNull] private static CoinService coinService;

    public static CoinService CoinService => coinService ??= new CoinService();

    [CanBeNull] private static GameStateManager gameStateManager;
    public static GameStateManager GameStateManager => gameStateManager ??= new GameStateManager();
}
