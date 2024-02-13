using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private BallFactoryData _ballFactoryData;
    [SerializeField] private BallSpawner _ballSpawner;

    public override void InstallBindings()
    {
        Container.BindInstance(_ballFactoryData).AsSingle();
        Container.Bind<BallFactory>().AsSingle();

        Container.BindInstance(_ballSpawner).AsSingle();
        Container.BindInterfacesAndSelfTo<BallCollectMediator>().AsSingle();

        //Container.BindInterfacesAndSelfTo<BallList>().AsSingle();
    }
}
