using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelectionButton : MonoBehaviour
{
    public event Action<VictoryConditions> Click;

    [SerializeField] VictoryConditions _victoryConditions;

    private Button _button;

    private void Awake()
        => _button = GetComponent<Button>();

    private void OnEnable()
        => _button.onClick.AddListener(OnClick);

    private void OnDisable()
        => _button.onClick.RemoveListener(OnClick);

    public void OnClick()
        => Click.Invoke(_victoryConditions);
}