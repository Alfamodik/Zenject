using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private HandleInput _handleInput;
    [SerializeField] private DeffeatPanel _deffeatPanel;

    [SerializeField] private LevelView _scoreView;
    [SerializeField] private HealthBar _healthBar;


    [SerializeField] private int _playerMaxHealth;
    
    private Player _player;

    private void Awake()
    {
        var playerHeapth = new Health(_playerMaxHealth);
        var playerLevel = new PlayerLevel(new Score(), 10);

        var level = new Level(playerHeapth);
        var _deffeatMediator = new DeffeatMediator(_deffeatPanel, level);

        _player = new Player(playerHeapth, playerLevel, level);
        
        _healthBar.Initialize(playerHeapth);
        _scoreView.Initilize(_player.Level);
        _handleInput.Initialize(new InputForMediator(), _player);
    }
}
