using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsConfig", menuName = "PlayerNoMonoSpawner/StatsConfig")]
public class PlayerStatsConfig : ScriptableObject
{
    [SerializeField, Range(0, 150)] private int _maxHealth;

    public int MaxHealth => _maxHealth;
}
