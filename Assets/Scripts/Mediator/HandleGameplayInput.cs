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
    private Player _player;

    [Inject]
    private void Construct(InputForMediator input, Player player)
    {
        _input = input;
        _player = player;

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
                _player.Health.GetDamage(_gamagePerExperience);
                _player.Level.Score.AddScore(_scorePerHealth);
                yield return new WaitForSeconds(_actionCooldown);
            }
            else if(_input.Get.Health.inProgress)
            {
                _player.Health.GetHeal(_healthPointPerHealth);
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