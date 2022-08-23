using UnityEngine;

public class HandMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _hand;
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private float _speed;

    private void Update()
    {      
        _hand.velocity = new Vector3(_joystick.Horizontal, _joystick.Vertical, Mathf.Abs(_joystick.Vertical * _joystick.Horizontal / 2)) * _speed;
    }
}
