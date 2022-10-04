using UnityEngine;

public class FootRaycast : MonoBehaviour
{
    [SerializeField] private Transform[] _positionPoints;
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private PlayerHealth _enemy;

    private RaycastHit _hit;
    private Transform _transform;
    private Transform _targetPosition;

    public Vector3 Position => _hit.point;
    public Vector3 Normal => _hit.normal;

    private void Awake()
    {
        _transform = base.transform;
        _targetPosition = _positionPoints[1];
    }

    private void OnEnable()
    {
        _player.ChangedHealth += OnDied;
        _enemy.ChangedHealth += OnDied;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= OnDied;
        _enemy.ChangedHealth -= OnDied;
    }

    private void Update()
    {
        var ray = new Ray(_targetPosition.position, new Vector3(0, -1, 0));
        Physics.Raycast(ray, out _hit);
    }

    private void OnDied(float currentHealth, float health)
    {
        _targetPosition = _positionPoints[Random.Range(0, _positionPoints.Length)];
    }
}
