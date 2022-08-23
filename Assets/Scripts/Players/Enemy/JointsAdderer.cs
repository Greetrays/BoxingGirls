using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointsAdderer : MonoBehaviour
{
    [SerializeField] private JointAdderer[] _adderers;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private MotionCorrector _motionCorrector;
    
    private Animator _animator;

    private void OnEnable()
    {
        _playerHealth.Died += OnDied;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        _playerHealth.Died -= OnDied;
    }

    private void OnDied()
    {
        _animator.enabled = false;
        _motionCorrector.enabled = false;

        foreach (var adderer in _adderers)
        {
            adderer.AddJoint();
        }
    }
}
