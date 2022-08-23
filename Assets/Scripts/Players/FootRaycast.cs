using UnityEngine;

public class FootRaycast : MonoBehaviour
{
    private RaycastHit _hit;
    private Transform _transform;

    public Vector3 Position => _hit.point;
    public Vector3 Normal => _hit.normal;

    private void Awake()
    {
        _transform = base.transform;
    }

    private void Update()
    {
        var ray = new Ray(_transform.position, new Vector3(0, -1, 0));
        Physics.Raycast(ray, out _hit);
    }
}
