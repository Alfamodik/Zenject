using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class LevelRestartButton : MonoBehaviour
{
    public event Action<VictoryConditions> Click;

    private VictoryConditions _victoryConditions;
    private Button _button;

    [Inject]
    private void Construct(LevelLoadingData data)
    {
        _victoryConditions = data.VictoryConditions;
        _button = GetComponent<Button>();
    }

    private void OnEnable()
        => _button.onClick.AddListener(OnClick);

    private void OnDisable()
        => _button.onClick.RemoveListener(OnClick);

    public void OnClick()
        => Click?.Invoke(_victoryConditions);
}