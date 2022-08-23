using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event UnityAction Died;
    public event UnityAction<float, float> ChangedHealth;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        ChangedHealth?.Invoke(_currentHealth, _maxHealth);
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            Died?.Invoke();
        }
    }
}
