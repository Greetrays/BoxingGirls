using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PillowCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleTemplate;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _maxImpactStrenght;
    [SerializeField] private float _damage;

    private Rigidbody _rigidbody;
    private float _currentImpactStrenght;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.name == _target.name)
        {
            _currentImpactStrenght = _rigidbody.velocity.magnitude * _rigidbody.mass;

            if (_currentImpactStrenght >= _maxImpactStrenght)
            {
                Instantiate(_particleTemplate, transform.position, Quaternion.identity);
                
                if (collision.transform.root.TryGetComponent(out PlayerHealth _playerHealth))
                {
                    _playerHealth.TakeDamage(_damage);
                }
            }
        }
    }
}
