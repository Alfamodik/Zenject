using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerNoMonoSpawner _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;

    [SerializeField] private PlayerStatsConfig _playerStatsConfig;

    public override void InstallBindings()
    {
        BindConfig();
        BindInstance();
    }

    private void BindInstance()
    {
        PlayerNoMonoSpawner player = Container.InstantiatePrefabForComponent<PlayerNoMonoSpawner>(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<PlayerNoMonoSpawner>().FromInstance(player).AsSingle();
    }

    private void BindConfig()
    {
        Container.Bind<PlayerStatsConfig>().FromInstance(_playerStatsConfig).AsSingle();
    }
}
