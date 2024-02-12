using UnityEngine;
using Zenject;

public class MainMenuHUD : MonoBehaviour
{
    [SerializeField]
    private LevelSelectionButton[] _levelSelectionButton;
    private SceneLoadMediator _sceneLoadMediator;

    [Inject]
    private void Construct(SceneLoadMediator sceneLoadMediator)
        => _sceneLoadMediator = sceneLoadMediator;

    private void OnEnable()
    {
        foreach(LevelSelectionButton levelSelectionButton in _levelSelectionButton)
            levelSelectionButton.Click += OnVictoryConditionsSelected;
    }

    private void OnDisable()
    {
        foreach(LevelSelectionButton levelSelectionButton in _levelSelectionButton)
            levelSelectionButton.Click -= OnVictoryConditionsSelected;
    }

    private void OnVictoryConditionsSelected(VictoryConditions victoryConditions)
        => _sceneLoadMediator.GoToGameplayLevel(new LevelLoadingData(victoryConditions));
}