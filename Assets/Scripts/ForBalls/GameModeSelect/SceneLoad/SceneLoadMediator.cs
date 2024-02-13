using Zenject;

public class SceneLoadMediator
{
    private ISimpleLevelLoader _simpleLevelLoader;
    private ILevelLoader _levelLoader;

    [Inject]
    private void Construct(ISimpleLevelLoader simpleLevelLoader, ILevelLoader levelLoader)
    {
        _simpleLevelLoader = simpleLevelLoader;
        _levelLoader = levelLoader;
    }

    public void GoToGameplayLevel(LevelLoadingData data)
        => _levelLoader.Load(data);

    public void GoToMainMenu()
        => _simpleLevelLoader.Load(SceneID.MainMenu);
}