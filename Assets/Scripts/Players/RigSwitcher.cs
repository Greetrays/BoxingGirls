using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigSwitcher : MonoBehaviour
{
    [SerializeField] private Rig _rig;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerHealth _enemyHealth;

    private void OnEnable()
    {
        _playerHealth.Died += OnDied;
        _enemyHealth.Died += OnDied;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= OnDied;
        _enemyHealth.Died -= OnDied;
    }

    private void OnDied()
    {
        _rig.weight = 0;
    }
}
