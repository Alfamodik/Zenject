using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar: MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    private Image _healthBar;
    private Health _health;

    public void Initialize(Health health)
    {
        _health = health;
        _healthBar = GetComponent<Image>();
        _health.OnHealthChanged += UpdateHealthBar;

        UpdateHealthBar();
    }

    private void OnDisable() => _health.OnHealthChanged -= UpdateHealthBar;

    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = (float)Convert.ToDouble(_health.GetHealth) / _health.MaxHealth;
        _healthBar.color = _gradient.Evaluate((float)Convert.ToDouble(_health.GetHealth) / _health.MaxHealth);
    }
}
