using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] private EnemySpawnerConfig _enemySpawnerConfig;
    public override void InstallBindings()
    {
        Container.BindInstance(_enemySpawnerConfig).AsSingle();

        Container.Bind<EnemyFactory>().AsSingle();
        Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();
    }
}
