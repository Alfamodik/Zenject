using System;
using System.Collections.Generic;
using UnityEngine;

public class BallCollectMediator : MonoBehaviour
{
    public event Action<BallColor> BallWasCollected;

    [SerializeField] private List<Ball> balls;

    private void Awake()
    {
        foreach(var ball in balls)
            ball.TheBallWasAssembled += WasCollected;
    }

    private void WasCollected(BallColor color)
        => BallWasCollected?.Invoke(color);
}