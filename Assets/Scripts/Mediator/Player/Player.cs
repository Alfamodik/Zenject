using System;

public class Player : IDisposable
{
    private Health _health;
    private PlayerLevel _level;
    private IRestartNotifies _restartNotifies;

    public Player(Health health, PlayerLevel level, IRestartNotifies restartNotifies)
    {
        _health = health;
        _level = level;

        _restartNotifies = restartNotifies;
        _restartNotifies.Restart += Reset;
    }

    public void Dispose() => _restartNotifies.Restart -= Reset;

    public Health Health => _health;

    public PlayerLevel Level => _level;

    public void Reset()
    {
        _health.Reset();
        _level.Reset();
    }
}
