using System;
using UnityEngine;
using UnityEngine.UI;

public class DeffeatPanel : MonoBehaviour
{
    public event Action OnButtonPressed;

    [SerializeField] private Button _restartButton;

    private void OnEnable() => _restartButton.onClick.AddListener(OnRestartClick);

    private void OnDisable() => _restartButton.onClick.RemoveListener(OnRestartClick);

    public void ShowMe() => gameObject.SetActive(true);

    public void HideMe() => gameObject.SetActive(false);

    private void OnRestartClick() => OnButtonPressed?.Invoke();
}
