using System;
using UnityEngine;

public class PlaceForBall : MonoBehaviour
{
    private bool _isFree = true;
    private Ball _currentBall;

    public bool IsFree => _isFree;

    public Ball Ball => _currentBall;

    public void Set(Ball coin)
    {
        if(_isFree == false)
            throw new Exception("This place is already occupied, use IsFree to check for availability");

        _currentBall = coin;
        _currentBall.TheBallWasAssembled += ToFree;

        _currentBall.Locate(transform);
        _isFree = false;
    }

    private void ToFree(BallColor _)
    {
        _isFree = true;
        _currentBall.TheBallWasAssembled -= ToFree;
    }
}
