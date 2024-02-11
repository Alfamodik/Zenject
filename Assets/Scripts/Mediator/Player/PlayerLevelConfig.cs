using UnityEngine;

[CreateAssetMenu(fileName = "PlayerLevelConfig", menuName = "Player/LevelConfig")]
public class PlayerLevelConfig : ScriptableObject
{
    [SerializeField] private int _scoreByUpgrade;

    public int ScoreByUpgrade => _scoreByUpgrade;
}