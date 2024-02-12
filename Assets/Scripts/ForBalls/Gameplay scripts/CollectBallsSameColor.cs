using System.Linq;
using UnityEngine;

public class CollectBallsSameColor : IVictoryConditions
{
    private int _countRedBalls;
    private int _countGreenBalls;
    private int _countBlueBalls;

    private int _countCollectedRedBalls;
    private int _countCollectedGreenBalls;
    private int _countCollectedBlueBalls;

    public CollectBallsSameColor()
    {
        _countRedBalls = GameObject.FindGameObjectsWithTag("Ball")
            .Select(_go => _go.GetComponent<Ball>())
            .Count(_ball => _ball.Color == BallColor.Red);

        _countGreenBalls = GameObject.FindGameObjectsWithTag("Ball")
            .Select(_go => _go.GetComponent<Ball>())
            .Count(_ball => _ball.Color == BallColor.Green);

        _countBlueBalls = GameObject.FindGameObjectsWithTag("Ball")
            .Select(_go => _go.GetComponent<Ball>())
            .Count(_ball => _ball.Color == BallColor.Blue);
    }

    public void AddBallsToCollected(BallColor ballColor)
    {
        switch (ballColor)
        {
            case BallColor.Red:
                _countCollectedRedBalls++;
                break;

            case BallColor.Green:
                _countCollectedGreenBalls++;
                break;

            case BallColor.Blue:
                _countCollectedBlueBalls++;
                break;
        }   
    }

    public bool IsVictory()
    {
        if (_countCollectedRedBalls == _countRedBalls && _countCollectedGreenBalls == 0 && _countCollectedBlueBalls == 0)
            return true;
        
        else if (_countCollectedRedBalls == 0 && _countCollectedGreenBalls == _countGreenBalls && _countCollectedBlueBalls == 0)
            return true;
        
        else if (_countCollectedRedBalls == 0 && _countCollectedGreenBalls == 0 && _countCollectedBlueBalls == _countBlueBalls)
            return true;

        return false;
    }
}
