using System.Collections;
using UnityEngine;
using Zenject;

public class HandleGameplayInput : MonoBehaviour
{
    [SerializeField] private int _gamagePerExperience;
    [SerializeField] private int _healthPointPerHealth;
    [SerializeField] private int _scorePerHealth;
    [SerializeField] private float _actionCooldown;

    private InputForMediator _input;
    private CharacterMediator _character;

    [Inject]
    private void Construct(InputForMediator input, CharacterMediator character)
    {
        _input = input;
        _character = character;

        _input.Enable();
        StartCoroutine(Handle());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        _input.Disable();
    }

    public IEnumerator Handle()
    {
        while (true)
        {
            if(_input.Get.Expierence.inProgress)
            {
                _character.Health.GetDamage(_gamagePerExperience);
                _character.Level.Score.AddScore(_scorePerHealth);
                yield return new WaitForSeconds(_actionCooldown);
            }
            else if(_input.Get.Health.inProgress)
            {
                _character.Health.GetHeal(_healthPointPerHealth);
                yield return new WaitForSeconds(_actionCooldown);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void Activate() => gameObject.SetActive(true);
    public void DeActivate() => gameObject.SetActive(false);
}