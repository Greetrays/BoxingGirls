using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    [SerializeField] private float _stepSpeed;
    [SerializeField] private AnimationCurve _stepCurve;

    private Vector3 _position;
    private Movement? _movement;
    private Transform _transform;

    public Vector3 Position => _position;
    public bool IsMoving => _movement != null;

    private void Awake()
    {
        _transform = base.transform;
        _position = _transform.position;
    }

    private void Update()
    {
        if (_movement != null)
        {
            var m = _movement.Value;
            m.Progress = Mathf.Clamp01(m.Progress + Time.deltaTime * _stepSpeed);
            _position = m.EvaLuate(Vector3.up, _stepCurve);
            _movement = m.Progress < 1 ? m : (Movement?)null; 
        }

        _transform.position = _position;
    }

    public void MoveTo(Vector3 targetPosition)
    {
        if (_movement == null)
        {
            _movement = new Movement
            {
                Progress = 0,
                FromPosition = _position,
                ToPosition = targetPosition
            };
        }
        else
        {
            _movement = new Movement
            {
                Progress = _movement.Value.Progress,
                FromPosition = _movement.Value.FromPosition,
                ToPosition = targetPosition
            };
        }
    }

    private struct Movement
    {
        public float Progress;
        public Vector3 FromPosition;
        public Vector3 ToPosition;

        public Vector3 EvaLuate(in Vector3 up, AnimationCurve stepCurve)
        {
            return Vector3.Lerp(@FromPosition, ToPosition, Progress) + up * stepCurve.Evaluate(Progress);
        }
    }
}
