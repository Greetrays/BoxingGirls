using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _hand;
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;

    private PlayerHealth _player;
    private float _elepsedTime;
    private float _verticalVelocity;
    private float _hotizontalVelocity;
    private bool _isLife;

    private void OnEnable()
    {
        _player = GetComponent<PlayerHealth>();
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void Update()
    {
        if (_isLife)
        {
            _elepsedTime += Time.deltaTime;

            if (_elepsedTime >= _delay)
            {
                _verticalVelocity = Random.Range(-1f, 1f);
                _hotizontalVelocity = Random.Range(-1f, 1f) * -1;
                _elepsedTime = 0;
            }

            _hand.velocity = new Vector3(Mathf.Abs(_verticalVelocity * _hotizontalVelocity / 2), _verticalVelocity, _hotizontalVelocity) * _speed;
        }
    }

    private void OnDied()
    {
        _isLife = false;
    }
}
