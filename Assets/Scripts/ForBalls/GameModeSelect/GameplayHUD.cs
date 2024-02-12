using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplayHUD : MonoBehaviour
{
    [SerializeField] private Button _button;

    private SceneLoadMediator _sceneLoadMediator;

    [Inject]
    private void Construct(SceneLoadMediator sceneLoadMediator)
        => _sceneLoadMediator = sceneLoadMediator;

    private void OnEnable()
        => _button.onClick.AddListener(OnMainMenuClick);

    private void OnDisable()
        => _button.onClick.RemoveListener(OnMainMenuClick);

    public void OnMainMenuClick()
        => _sceneLoadMediator.GoToMainMenu();
}
