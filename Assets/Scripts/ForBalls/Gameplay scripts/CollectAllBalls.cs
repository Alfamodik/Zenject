using System.Linq;
using UnityEngine;

public class CollectAllBalls : IVictoryConditions
{
    private int _countBalls;
    private int _countCollectedBalls;

    public CollectAllBalls()
        => _countBalls = GameObject.FindGameObjectsWithTag("Ball")
                .Count(_go => _go.GetComponent<Ball>());

    public void AddBallsToCollected(BallColor ballColor)
        => _countCollectedBalls++;

    public bool IsVictory()
    {
        if (_countCollectedBalls == _countBalls)
            return true;
        else
            return false;
    }
}