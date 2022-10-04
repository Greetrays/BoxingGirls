using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class WinParticleLauncher : MonoBehaviour
{
    [SerializeField] private PlayerHealth _enemy;

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
        gameObject.GetComponent<ParticleSystem>().Play();
    }
}
