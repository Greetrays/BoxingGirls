using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSwitcher : MonoBehaviour
{
    [SerializeField] private PlayerHealth _enemyHealth;
    [SerializeField] private RuntimeAnimatorController _controller;

    private Animator _animator;

    private void OnEnable()
    {
        _enemyHealth.Died += OnDied;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        _enemyHealth.Died -= OnDied;
    }

    private void OnDied()
    {
        _animator.runtimeAnimatorController = _controller;
    }
}
