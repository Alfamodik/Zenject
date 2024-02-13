using System;

public class Health : INotifiesAtDeath
{
    public event Action Death;
    public event Action OnHealthChanged;

    public readonly int MaxHealth;
    private int _health;

    public Health(HealthConfig config)
    {
        if(config.MaxHealth < 0)
            throw new ArgumentOutOfRangeException(nameof(config.MaxHealth), "Начальное здоровье не может быть меньше нуля!");

        _health = config.StartHealth;
        MaxHealth = config.MaxHealth;

        OnHealthChanged?.Invoke();
    }

    public int GetHealth => _health;

    public void GetDamage(int damage)
    {
        if(damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage), "Урон не может быть меньше или равет нулю!");

        _health -= damage;
        OnHealthChanged?.Invoke();

        if(_health < 0)
        {
            _health = 0;
            Death?.Invoke();
        }
    }

    public void GetHeal(int heal)
    {
        if(heal <= 0)
            throw new ArgumentOutOfRangeException(nameof(heal), "Восстановление не может быть меньше или равет нулю!");

        if((_health + heal) > MaxHealth)
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