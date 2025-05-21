using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private float _moveSpeed;

    private Camera _camera;
    private Transform _transform;
    private Rigidbody2D _rb;

    public Vector2 MouseDirection { get; private set; }
    public Vector2 MovementDirection { get; private set; }
    public float CharacterAngle { get; private set; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _camera = Camera.main;
        _transform = transform;
    }

    private void Update()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Mouse.current.position.value);

        MouseDirection = mousePosition - _transform.position;
        MovementDirection = _moveAction.action.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        RotateCharacter();

        _rb.linearVelocity = MovementDirection * _moveSpeed;
    }

    private void RotateCharacter()
    {
        CharacterAngle = (Mathf.Atan2(MouseDirection.y, MouseDirection.x) * Mathf.Rad2Deg) + 180f;
        _rb.MoveRotation(CharacterAngle);
    }
}
