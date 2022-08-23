using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpuls : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private PlayerHealth _enemy;
    [SerializeField] private Rigidbody _rigidbody;

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
        _rigidbody.AddForce(new Vector3(0, 0.2f, -1) * _force, ForceMode.Impulse);
    }

    private void EnemyHealthChanged(float currentHealt, float maxHealth)
    {
        _rigidbody.AddForce(new Vector3(0, 0.2f, 1) * _force, ForceMode.Impulse);
    }
}
