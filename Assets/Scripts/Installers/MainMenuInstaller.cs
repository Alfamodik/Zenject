using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    [SerializeField] MainMenuHUD _mainMenuHUD;

    public override void InstallBindings()
    {
        Container.BindInstance(_mainMenuHUD).AsSingle();
    }
}