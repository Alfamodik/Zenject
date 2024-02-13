using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class BallFactory
{
    private BallFactoryData _prefabs;

    public BallFactory(BallFactoryData prefabs)
        => _prefabs = prefabs;

    public Ball Get()
        => MonoBehaviour.Instantiate(GetRandomFrefab());

    private Ball GetRandomFrefab()
    {
        switch(Random.Range(1, 4))
        {
            case 1:
                return _prefabs.Red;

            case 2:
                return _prefabs.Green;

            case 3:
                return _prefabs.Blue;

            default:
                throw new NotImplementedException();
        }
    }
}