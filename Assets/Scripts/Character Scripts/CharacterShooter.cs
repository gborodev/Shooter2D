using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterShooter : MonoBehaviour
{
    [SerializeField] private InputActionReference _fireAction;
    [SerializeField] private GunSO _testGun;

    private GunObject _gun;

    private void Start()
    {
        if (_testGun == null) return;

        _gun = GetComponentInChildren<GunObject>();
        _gun.Initialize(_testGun);
    }

    private void Update()
    {
        if (_gun == null) return;

        if (_gun.CanFire && _fireAction.action.IsPressed())
        {
            _gun.Fire();
        }
    }
}
