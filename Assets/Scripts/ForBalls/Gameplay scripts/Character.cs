using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [SerializeField] private float speed;
    private CaracterInput _input;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();

        _input = new CaracterInput();
        _input.Enable();
    }

    private void OnDestroy()
        => _input.Disable();

    private void Update()
    {
        Vector2 directory = _input.Movement.Move.ReadValue<Vector2>().normalized;
        _rigidBody.AddForce(speed * Time.deltaTime * new Vector3(directory.x, 0f, directory.y),
            ForceMode.Acceleration);
    }
}