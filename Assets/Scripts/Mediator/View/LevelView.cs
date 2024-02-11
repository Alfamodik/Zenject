using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LevelView : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private PlayerLevel _playerLevel;

    public void Initilize(PlayerLevel playerLevel)
    {
        _playerLevel = playerLevel;
        _text = GetComponent<TextMeshProUGUI>();
        _playerLevel.Score.OnScoreChanged += UpdateScore;

        UpdateScore();
    }

    private void OnDisable() => _playerLevel.Score.OnScoreChanged -= UpdateScore;

    public void UpdateScore() => _text.text = _playerLevel.Level.ToString();
}
