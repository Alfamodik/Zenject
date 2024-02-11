using UnityEngine;

[CreateAssetMenu(fileName = "HealthCoifig", menuName = "Player/HealthConfig")]
public class HealthConfig : ScriptableObject
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _startHealth;

    public int MaxHealth => _maxHealth;

    public int StartHealth => _startHealth;
}