using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Pillow : MonoBehaviour
{
    [SerializeField] private CharacterJoint _characterJoint;
    [SerializeField] private PlayerHealth _player;
    
    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void OnDied()
    {
        Die();
        _rigidbody.AddForce(new Vector3(-2, 0, 1), ForceMode.Impulse);
    }

    public void Die()
    {
        Destroy(_characterJoint);
        transform.parent = null;
    }

}
