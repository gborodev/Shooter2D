using UnityEngine;

[CreateAssetMenu(menuName = "Data/Gun", fileName = "New Gun")]
public class GunSO : ScriptableObject
{
    [SerializeField] private BulletObject _bullet;

    [SerializeField, Min(30)] private int _magazineLimit = 30;
    [SerializeField, Min(0.2f)] private float _fireRate = 0.2f;

    public BulletObject Bullet { get { return _bullet; } }
    public float FireRate { get { return _fireRate; } }
    public int Magazine { get { return _magazineLimit; } }

}
