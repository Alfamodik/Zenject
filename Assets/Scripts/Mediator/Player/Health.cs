using System;
using UnityEngine;

public class Health : INotifiesAtDeath
{
    public event Action Death;
    public event Action OnHealthChanged;

    public readonly int MaxHealth;
    private int _health;
    
    public Health(int maxHealth)
    {
        if (maxHealth < 0)
            throw new ArgumentOutOfRangeException(nameof(maxHealth), "Начальное здоровье не может быть меньше нуля!");

        _health = maxHealth;
        MaxHealth = maxHealth;
    }

    public int GetHealth => _health;

    public void GetDamage(int damage)
    {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage), "Урон не может быть меньше или равет нулю!");

        _health -= damage;
        OnHealthChanged?.Invoke();

        if (_health < 0)
        {
            _health = 0;
            Death?.Invoke();
        }
    }

    public void GetHeal(int heal)
    {
        if (heal <= 0)
            throw new ArgumentOutOfRangeException(nameof(heal), "Восстановление не может быть меньше или равет нулю!");

        if ((_health + heal) > MaxHealth)
            _health = MaxHealth;
        else
            _health += heal;

        OnHealthChanged?.Invoke();
    }

    public void Reset()
    {
        _health = MaxHealth;
        OnHealthChanged?.Invoke();
    }
}