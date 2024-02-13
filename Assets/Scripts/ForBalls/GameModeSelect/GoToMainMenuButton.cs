using System;
using UnityEngine;
using UnityEngine.UI;

public class GoToMainMenuButton : MonoBehaviour
{
    public event Action Click;
    private Button _button;

    private void Awake()
        => _button = GetComponent<Button>();

    private void OnEnable()
        => _button.onClick.AddListener(OnClick);

    private void OnDisable()
        => _button.onClick.RemoveListener(OnClick);

    public void OnClick()
        => Click?.Invoke();
}
