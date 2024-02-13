using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemySpawnerConfig
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<Transform> _spawnPoints;

    public float SpawnCooldown => _spawnCooldown;
    public List<Transform> SpawnPoints => _spawnPoints;
}