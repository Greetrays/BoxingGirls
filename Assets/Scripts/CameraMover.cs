using UnityEngine;
using DG.Tweening;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private GameObject _cineMacheine;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _zOffset;
    [SerializeField] private Transform _target;
    [SerializeField] private PlayerHealth _enemy;
    [SerializeField] private float _animationTime;
    [SerializeField] private Ease _ease;

    private Vector3 _targetPosition;

    private void OnEnable()
    {
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _enemy.Died -= OnDied;
    }

    private void OnDied()
    {
        _targetPosition = new Vector3(_target.position.x, _target.position.y + _yOffset, _target.position.z + _zOffset);
        _cineMacheine.SetActive(false);
        transform.DOMove(_targetPosition, _animationTime).SetEase(_ease);
        transform.DODynamicLookAt(_target.position, _animationTime);
    }
}
