using System;
using UnityEngine;

public class Ball : Locateable
{
    public event Action<BallColor> TheBallWasAssembled;

    [SerializeField] private BallColor _color;

    public BallColor Color => _color;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            TheBallWasAssembled?.Invoke(_color);
            Destroy(gameObject);
        }
    }

    public void SetPosition(Vector3 position)
        => transform.position = position;
}