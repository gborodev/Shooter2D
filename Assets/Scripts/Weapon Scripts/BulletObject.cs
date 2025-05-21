using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class BulletObject : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform _transform;

    private float angle;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _transform = transform;
    }

    public void Shoot(float characterAngle)
    {
        angle = characterAngle;

        gameObject.SetActive(true);

        _rb.MoveRotation(characterAngle);
        _rb.AddForce(_transform.right * -1 * 180f, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.TryGetComponent(out EnemyObject enemyObject))
            {
                enemyObject.TakeHit(collision.contacts[0].point, angle);
            }
        }
        gameObject.SetActive(false);
    }
}
