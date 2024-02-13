using System.Linq;
using UnityEngine;
using Zenject;

public class CollectAllBalls : IVictoryConditions
{
    private int _countBalls;
    private int _countCollectedBalls;

    public CollectAllBalls(BallSpawner spawner) => _countBalls = spawner.GetSpawnedBalls.Count();

    public void AddBallsToCollected(BallColor ballColor) => _countCollectedBalls++;

    public bool IsVictory()
    {
        if (_countCollectedBalls == _countBalls)
            return true;

        else
            return false;
    }

    public bool WinToImpossible() => false;
}