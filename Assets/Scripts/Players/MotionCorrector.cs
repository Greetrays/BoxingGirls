using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionCorrector : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private Vector3 _startTargetPosition = new Vector3();
    private Vector3 _oldPosition = new Vector3();

    private void Start()
    {
        _startTargetPosition = _target.position;
        _oldPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _oldPosition + _target.position - _startTargetPosition, _speed * Time.deltaTime);
    }
}
