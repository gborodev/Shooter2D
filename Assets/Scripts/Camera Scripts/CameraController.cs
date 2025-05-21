using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _followSpeed = 0.3f;
    [SerializeField] private float _offsetLimit = 2f;

    private Transform _transform;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _transform = transform;
    }

    private void LateUpdate()
    {
        if (_target == null) return;

        Vector3 mousePosition = _camera.ScreenToWorldPoint(Mouse.current.position.value);
        Vector3 direction = mousePosition - _target.position;

        Vector3 targetPosition = _target.position + (direction.normalized * _offsetLimit);
        targetPosition.z = _transform.position.z;

        _transform.position = Vector3.Lerp(_transform.position, targetPosition, _followSpeed * Time.deltaTime);
    }
}
