public interface IVictoryConditions
{
    void AddBallsToCollected(BallColor ball);

    bool IsVictory();

    bool WinToImpossible();
}