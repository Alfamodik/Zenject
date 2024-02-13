using System;

public class CharacterMediator : IDisposable
{
    private Health _health;
    private PlayerLevel _level;
    private IRestartNotifier _restartNotifies;

    public CharacterMediator(Health health, PlayerLevel level, IRestartNotifier restartNotifies)
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
