using UnityEngine;

public class HandleInput : MonoBehaviour
{
    [SerializeField] private int _gamagePerExperience;
    [SerializeField] private int _healthPointPerHealth;

    [SerializeField] private float _actionCooldown;
    private float _remairingCooldown;

    private InputForMediator _input;
    private Player _player;

    public void Initialize(InputForMediator input, Player player)
    {
        _input = input;
        _player = player;

        _input.Enable();
    }

    private void OnDestroy() => _input.Disable();

    private void Update()
    {
        if(_input == null)
            Debug.LogWarning("HandleInput, _input == null");

        if (_remairingCooldown > 0)
        {
            _remairingCooldown -= Time.deltaTime;
        }
        else if (_input.Get.Expierence.inProgress)
        {
            _player.Health.GetDamage(_gamagePerExperience);
            _player.Level.Score.AddScore(1);
            _remairingCooldown = _actionCooldown;
        }
        else if (_input.Get.Health.inProgress)
        {
            _player.Health.GetHeal(_healthPointPerHealth);
            _remairingCooldown = _actionCooldown;
        }
    }

    public void Activate() => gameObject.SetActive(true);
    public void DeActivate() => gameObject.SetActive(false);
}