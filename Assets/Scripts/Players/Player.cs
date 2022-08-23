using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerHealth))]

public class Player : MonoBehaviour
{
    [SerializeField] private Pillow _pillow;
    [SerializeField] private PlayerHealth _enemy;
    [SerializeField] private Joint[] _joints;
    [SerializeField] private Rigidbody[] _rigidbodyComponents;
    [SerializeField] private Rigidbody _hipsRigidbody;
    [SerializeField] private ConfigurableJoint _hips;
    [SerializeField] private Rigidbody _spine;
    [SerializeField] private float _reboundForceY;
    [SerializeField] private float _reboundForceZ;

    private Animator _animator;
    private PlayerHealth _playerHealth;

    private void OnEnable()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _enemy.Died += OnDied;
        _playerHealth.Died += Die;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        _enemy.Died -= OnDied;
        _playerHealth.Died -= Die;
    }

    private void OnDied()
    {
        _animator.enabled = true;
        _pillow.Die();

        _hipsRigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;

        foreach (var item in _joints)
        {
            Destroy(item);       
        }

        foreach (var item in _rigidbodyComponents)
        {
            item.isKinematic = true;
        }
    }

    private void Die()
    {
        _hipsRigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;

        /*for (int i = 0; i < _hingeJoints.Length; i++)
        {
            _hingeJoints[i].useSpring = false;
        }*/

        JointDrive newJointDrive = new JointDrive();
        newJointDrive.positionSpring = 0;
        newJointDrive.positionDamper = 0;
        newJointDrive.maximumForce = _hips.slerpDrive.maximumForce;

        _hips.slerpDrive = newJointDrive;

        _spine.AddForce(new Vector3(0, _reboundForceY, _reboundForceZ), ForceMode.Impulse);
    }
}
