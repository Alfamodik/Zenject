using System;
using UnityEngine;
using Zenject;

public class GameResultHandler : MonoBehaviour
{
    private IVictoryConditions _victoryConditions;
    private BallCollectMediator _ballCollectMediator;

    [Inject]
    public void Construct(LevelLoadingData data, BallCollectMediator ballCollectMediator)
    {
        _ballCollectMediator = ballCollectMediator;
        _ballCollectMediator.BallWasCollected += BallWasAssembled;

        switch(data.VictoryConditions)
        {
            case VictoryConditions.CollectAllBalls:
                SetVictoryCondition(new CollectAllBalls());
                Debug.Log("��� ������ �������� ��� ����!");
                break;

            case VictoryConditions.CollectBallsSameColor:
                SetVictoryCondition(new CollectBallsSameColor());
                Debug.Log("��� ������ �������� ��� ���� ������ �����!");
                break;

            default:
                throw new ArgumentException(nameof(data.VictoryConditions));
        }
    }

    private void SetVictoryCondition(IVictoryConditions victoryConditions)
        => _victoryConditions = victoryConditions;

    private void BallWasAssembled(BallColor ballColor)
    {
        _victoryConditions.AddBallsToCollected(ballColor);

        if (_victoryConditions.IsVictory())
            Debug.Log("�� ��������!");
            //show panel
    }
}