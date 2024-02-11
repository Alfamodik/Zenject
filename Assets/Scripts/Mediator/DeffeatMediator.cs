using System;

public class DeffeatMediator : IDisposable
{
    private DeffeatPanel _deffeatPanel;
    private Level _level;

    public DeffeatMediator(DeffeatPanel deffeatPanel, Level level)
    {
        _level = level;
        _deffeatPanel = deffeatPanel;

        _level.Defeat += OnLevelDeffeat;
        _deffeatPanel.OnButtonPressed += RestartLevel;
    }

    public void Dispose()
    {
        _level.Defeat -= OnLevelDeffeat;
        _deffeatPanel.OnButtonPressed -= RestartLevel;
    }

    private void OnLevelDeffeat() => _deffeatPanel.ShowMe();

    public void RestartLevel()
    {
        _deffeatPanel.HideMe();
        _level.Restarting();
    }
}
