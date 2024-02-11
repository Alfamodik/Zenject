using System;

public class Score
{
    public event Action OnScoreChanged;

    private int _score;

    public int GetScore => _score;

    public void AddScore(int score)
    {
        if (score <= 0)
            throw new ArgumentOutOfRangeException(nameof(score), "Нельзя добавить отрицательный или равный нулю счёт");

        _score += score;
        OnScoreChanged?.Invoke();
    }

    public void Reset()
    {
        _score = 0;
        OnScoreChanged?.Invoke();
    }
}