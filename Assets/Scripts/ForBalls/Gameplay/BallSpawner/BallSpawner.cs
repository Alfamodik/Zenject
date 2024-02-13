using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private int _countEnemy;
    [SerializeField] private List<PlaceForBall> _spawnPoints;
    private List<PlaceForBall> _freePoints;

    private BallFactory _factory;

    [Inject]
    private void Construct(BallFactory factory) => _factory = factory;

    public List<Ball> GetSpawnedBalls
        => _spawnPoints.Where(place => place.Ball != null)
            .Select(place => place.Ball).ToList();

    private void OnValidate()
    {
        if(_countEnemy >= _spawnPoints.Count)
            _countEnemy = _spawnPoints.Count;

        if(_countEnemy < 0)
            _countEnemy = 0;
    }

    private void Awake()
    {
        for(int i = 0; i < _countEnemy; i++)
            Spawn();
    }

    private void Spawn()
    {
        SetAvailability();
        GetRandomPoint().Set(_factory.Get());
    }

    private PlaceForBall GetRandomPoint() => _freePoints[Random.Range(0, _freePoints.Count - 1)];

    private void SetAvailability() => _freePoints = _spawnPoints.Where(el => el.IsFree).ToList();
}
