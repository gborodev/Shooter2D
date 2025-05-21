using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GunObject : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private Light2D _flashLight;

    private CharacterMovement _characterMovement;
    private GunSO _gunData;

    private float _fireTime = 0f;

    public bool CanFire { get { return _fireTime <= 0f; } }

    private Queue<BulletObject> _bulletObjects;

    private void Start()
    {
        _characterMovement = GetComponentInParent<CharacterMovement>();
    }

    public void Initialize(GunSO data)
    {
        _gunData = data;

        _bulletObjects = new Queue<BulletObject>();

        for (int i = 0; i < 100; i++)
        {
            BulletObject bullet = Instantiate(_gunData.Bullet, _bulletSpawnPoint);
            bullet.gameObject.SetActive(false);

            _bulletObjects.Enqueue(bullet);
        }
    }

    private void Update()
    {
        if (_fireTime > 0f)
        {
            _fireTime -= Time.deltaTime;
        }
    }

    public void Fire()
    {
        if (_gunData == null) return;

        _fireTime = _gunData.FireRate;

        BulletObject bullet = _bulletObjects.Dequeue();
        bullet.Shoot(_characterMovement.CharacterAngle);

        _bulletObjects.Enqueue(bullet);

        StartCoroutine(FlashCoroutine(0.1f));
    }

    private IEnumerator FlashCoroutine(float flashTime)
    {
        float initialRadius = Random.Range(7f, 10f);
        _flashLight.pointLightOuterRadius = initialRadius;

        float elapsed = 0f;
        while (elapsed < flashTime)
        {
            float t = elapsed / flashTime;

            _flashLight.pointLightOuterRadius = Mathf.Lerp(initialRadius, 0f, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        _flashLight.pointLightOuterRadius = 0f;
    }
}
