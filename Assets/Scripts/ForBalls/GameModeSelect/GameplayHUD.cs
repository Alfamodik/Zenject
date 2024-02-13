using UnityEngine;
using Zenject;

public class GameplayHUD : MonoBehaviour
{
    [SerializeField] private LevelRestartButton _levelRestartButton;
    [SerializeField] private GoToMainMenuButton _goToMainMenuButton;

    private SceneLoadMediator _sceneLoadMediator;

    [Inject]
    private void Construct(SceneLoadMediator sceneLoadMediator)
        => _sceneLoadMediator = sceneLoadMediator;

    private void OnEnable()
    {
        _goToMainMenuButton.Click += GoToMainMenu;
        _levelRestartButton.Click += RestartCurrentLevel;
    }

    private void OnDisable()
    {
        _goToMainMenuButton.Click -= GoToMainMenu;
        _levelRestartButton.Click -= RestartCurrentLevel;
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    public void RestartCurrentLevel(VictoryConditions victoryConditions)
        => _sceneLoadMediator.GoToGameplayLevel(new LevelLoadingData(victoryConditions));

    public void GoToMainMenu()
        => _sceneLoadMediator.GoToMainMenu();
}
