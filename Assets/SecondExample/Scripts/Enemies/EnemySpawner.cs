using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : ITickable, IPause
{
    private List<Transform> _spawnPoints;
    private EnemyFactory _enemyFactory;

    private float _spawnCooldown;
    private float _remainingSpawnCooldown;

    private bool _isPaused;
    private bool _isActive;

    [Inject]
    private void Construct(EnemyFactory enemyFactory, EnemySpawnerConfig config, PauseHandler pauseHandler)
    {
        _enemyFactory = enemyFactory;
        pauseHandler.Add(this);

        _spawnCooldown = config.SpawnCooldown;
        _spawnPoints = config.SpawnPoints;
    }

    public void StartWork() => _isActive = true;
    public void StopWork() => _isActive = false;

    public void SetPause(bool isPause) => _isPaused = isPause;

    public void Tick()
    {
        if(_isPaused)
            return;

        if(_isActive == false)
            return;

        if(_remainingSpawnCooldown <= 0)
            Spawn();
        else
            _remainingSpawnCooldown -= Time.deltaTime;
    }
    private void Spawn()
    {
        Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
        enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
        _remainingSpawnCooldown = _spawnCooldown;
    }
}