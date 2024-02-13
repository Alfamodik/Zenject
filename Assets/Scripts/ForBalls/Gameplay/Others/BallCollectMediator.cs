using System;
using System.Collections.Generic;
using UnityEngine;

public class BallCollectMediator : IDisposable
{
    public event Action<BallColor> BallWasCollected;

    private List<Ball> _balls;

    public BallCollectMediator(BallSpawner spawner)
    {
        _balls = spawner.GetSpawnedBalls;

        foreach (var ball in _balls)
            ball.TheBallWasAssembled += WasCollected;
    }
    
    public void Dispose()
    {
        foreach(var ball in _balls)
            ball.TheBallWasAssembled -= WasCollected;
    }

    private void WasCollected(BallColor color)
        => BallWasCollected?.Invoke(color);
}