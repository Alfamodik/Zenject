using System;

public class SceneLoader : ISimpleLevelLoader, ILevelLoader
{
    private ZenjectSceneLoaderWrapper _sceneLoader;

    public SceneLoader(ZenjectSceneLoaderWrapper sceneLoader)
        => _sceneLoader = sceneLoader;

    public void Load(LevelLoadingData data)
    {
        _sceneLoader.Load(container =>
        {
            container.BindInstance(data).AsSingle();
        }, (int)SceneID.Gameplay);
    }

    public void Load(SceneID sceneID)
    {
        if(sceneID == SceneID.Gameplay)
            throw new ArgumentException($"{nameof(sceneID)} cannot be startet without configuration, use ILevelLoader");
        
        _sceneLoader.Load(null, (int)sceneID);
    }
}