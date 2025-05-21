using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bloodParticle;

    public void TakeHit(Vector3 position, float angle)
    {
        if (_bloodParticle != null)
        {
            ParticleSystem particle = Instantiate(_bloodParticle, position, Quaternion.Euler(0, 0, angle));

            particle.Play();
        }
    }
}
