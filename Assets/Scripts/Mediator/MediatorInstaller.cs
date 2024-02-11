using UnityEngine;
using Zenject;

public class MediatorInstaller : MonoInstaller
{
    [Header("Player")]
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private PlayerLevelView _playerLevelView;
    [Space]
    [SerializeField] private HealthConfig _healthConfig;
    [SerializeField] private PlayerLevelConfig _playerLevelConfig;
    [Space(20)]
    [SerializeField] private DeffeatPanel _deffeatPanel;
    [SerializeField] private HandleGameplayInput _handleInput;

    public override void InstallBindings()
    {
        BindPlayer();

        Container.Bind<DeffeatPanel>().FromInstance(_deffeatPanel).AsSingle();
        Container.BindInterfacesAndSelfTo<DeffeatMediator>().AsSingle().NonLazy();
    }

    private void BindPlayer()
    {
        BindPlayerDependencies();

        Container.BindInterfacesAndSelfTo<Player>().AsSingle();

        BindPlayerAddOns();
    }

    private void BindPlayerDependencies()
    {
        Container.Bind<PlayerLevelConfig>().FromInstance(_playerLevelConfig).AsSingle();
        Container.Bind<HealthConfig>().FromInstance(_healthConfig).AsSingle();

        Container.Bind<Score>().AsSingle();
        Container.Bind<PlayerLevel>().AsSingle();

        Container.BindInterfacesAndSelfTo<Health>().AsSingle();

        Container.BindInterfacesAndSelfTo<Level>().AsSingle();
    }

    private void BindPlayerAddOns()
    {
        Container.Bind<PlayerLevelView>().FromInstance(_playerLevelView).AsSingle().NonLazy();
        Container.Bind<HealthBar>().FromInstance(_healthBar).AsSingle().NonLazy();

        Container.BindInterfacesAndSelfTo<InputForMediator>().AsSingle();
        Container.Bind<HandleGameplayInput>().FromInstance(_handleInput).AsSingle().NonLazy();
    }
}