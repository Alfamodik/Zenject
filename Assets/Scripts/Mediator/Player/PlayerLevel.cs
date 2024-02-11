public class PlayerLevel
{
    private int _level;
    private readonly int scoreByUpgrade;
    private Score _score;

    public PlayerLevel(Score score, int scoreByUpgradeLevel)
    {
        scoreByUpgrade = scoreByUpgradeLevel;
        _score = score;
        _score.OnScoreChanged += UpdateInfoByLevel;
    }

    public int Level => _level;
    public Score Score => _score;
    
    private void UpdateInfoByLevel()
    {
        if (_score.GetScore > scoreByUpgrade)
        {
            _level += 1;
            _score.Reset();
        }
    }

    public void Reset()
    {
        _level = 0;
        _score.Reset();
    }
}