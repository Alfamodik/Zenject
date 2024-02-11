using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerLevelView : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private PlayerLevel _playerLevel;

    [Inject]
    private void Construct(PlayerLevel playerLevel)
    {
        _playerLevel = playerLevel;
        _text = GetComponent<TextMeshProUGUI>();
        _playerLevel.Score.OnScoreChanged += UpdateScore;

        UpdateScore();
    }

    private void OnDisable() => _playerLevel.Score.OnScoreChanged -= UpdateScore;

    public void UpdateScore() => _text.text = _playerLevel.Level.ToString();
}