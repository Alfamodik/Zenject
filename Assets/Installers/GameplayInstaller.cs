using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] BallCollectMediator _ballCollectMediator;

    public override void InstallBindings()
    {
        Container.BindInstance(_ballCollectMediator).AsSingle();
    }
}
