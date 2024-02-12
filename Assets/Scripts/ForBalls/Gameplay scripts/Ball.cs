using System;
using UnityEngine;

public enum BallColor
{
    Red,
    Green,
    Blue
}

public class Ball : MonoBehaviour
{
    public event Action<BallColor> TheBallWasAssembled;
    
    [SerializeField] private BallColor _color;

    public BallColor Color => _color;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TheBallWasAssembled?.Invoke(_color);
            Destroy(gameObject);
        }
    }
}