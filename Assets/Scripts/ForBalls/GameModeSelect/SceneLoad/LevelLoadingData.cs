public class LevelLoadingData
{
    private VictoryConditions _victoryConditions;

    public LevelLoadingData(VictoryConditions victoryConditions)
        => _victoryConditions = victoryConditions;

    public VictoryConditions VictoryConditions => _victoryConditions;
}