using UnityEngine;

[CreateAssetMenu(fileName = "BallFactoryData", menuName = "Factory/BallFactoryData")]
public class BallFactoryData : ScriptableObject
{
    [SerializeField] private Ball _red;
    [SerializeField] private Ball _green;
    [SerializeField] private Ball _blue;

    public Ball Red => _red;
    
    public Ball Green => _green;

    public Ball Blue => _blue;
}
