using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpuls : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private PlayerHealth _enemy;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _impulseDirection;

    private void OnEnable()
    {
        _player.ChangedHealth += PlayerHealthChanged;
        _enemy.ChangedHealth += EnemyHealthChanged;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= PlayerHealthChanged;
        _enemy.ChangedHealth -= EnemyHealthChanged;
    }

    private void PlayerHealthChanged(float currentHealt, float maxHealth)
    {
        Vector3 newDirection = new Vector3(_impulseDirection.x, _impulseDirection.y, _impulseDirection.z * -1);
        _rigidbody.AddForce(newDirection * _force, ForceMode.Impulse);
    }

    private void EnemyHealthChanged(float currentHealt, float maxHealth)
    {
        _rigidbody.AddForce(_impulseDirection * _force, ForceMode.Impulse);
    }
}
