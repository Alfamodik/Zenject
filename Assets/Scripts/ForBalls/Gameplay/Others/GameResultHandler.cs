using System;
using UnityEngine;
using Zenject;

public class GameResultHandler : MonoBehaviour
{
    [SerializeField] private GameplayHUD gameplayHUD;
    [SerializeField] private ResultMenuConfig _resultConfig;

    private IVictoryConditions _victoryConditions;
    private BallCollectMediator _ballCollectMediator;

    private LevelLoadingData _data;
    private BallSpawner _spawner;

    [Inject]
    private void Construct(LevelLoadingData data, BallSpawner spawner)
    {
        _data = data;
        _spawner = spawner;
    }

    private ResultMenuHeaderConfig Victory => _resultConfig.Victory;
    private ResultMenuHeaderConfig Deffeat => _resultConfig.Deffeat;

    private void Start()
    {
        _ballCollectMediator = new BallCollectMediator(_spawner);
        _ballCollectMediator.BallWasCollected += BallWasAssembled;

        switch(_data.VictoryConditions)
        {
            case VictoryConditions.CollectAllBalls:
                SetVictoryCondition(new CollectAllBalls(_spawner));
                break;

            case VictoryConditions.CollectBallsSameColor:
                SetVictoryCondition(new CollectBallsSameColor(_spawner));
                break;

            default:
                throw new NotImplementedException(nameof(_data.VictoryConditions));
        }
    }

    private void OnDestroy() => _ballCollectMediator.BallWasCollected -= BallWasAssembled;

    private void SetVictoryCondition(IVictoryConditions victoryConditions)
    {
        Debug.Log($"{victoryConditions}");
        _victoryConditions = victoryConditions;
    }

    private void BallWasAssembled(BallColor ballColor)
    {
        Debug.Log("AddBallsToCollected");

        _victoryConditions.AddBallsToCollected(ballColor);

        if(_victoryConditions.IsVictory())
        {
            Debug.Log($"IsVictory {_victoryConditions.IsVictory()}");
            gameplayHUD.Show(Victory.Text, Victory.Color);
        }
        else if(_victoryConditions.WinToImpossible())
        {
            Debug.Log($"WinToImpossible {_victoryConditions.WinToImpossible()}");
            gameplayHUD.Show(Deffeat.Text, Deffeat.Color);
        }
    }
}