using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _hand;
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;

    private float _elepsedTime;
    private float _verticalVelocity;
    private float _hotizontalVelocity;

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _delay)
        {
            _verticalVelocity = Random.Range(-1f, 1f);
            _hotizontalVelocity = Random.Range(-1f, 1f) * -1;
            _elepsedTime = 0;
        }

        _hand.velocity = new Vector3(Mathf.Abs(_verticalVelocity * _hotizontalVelocity / 2), _verticalVelocity, _hotizontalVelocity)  * _speed;
    }
}
