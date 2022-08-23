using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Image _bar;

    private Coroutine _changeHealthCoroutine;

    private void OnEnable()
    {
        _playerHealth.ChangedHealth += OnChangedHealth;
    }

    private void OnChangedHealth(float value, float maxValue)
    {
        if (_changeHealthCoroutine != null)
            StopCoroutine(_changeHealthCoroutine);

        _changeHealthCoroutine = StartCoroutine(ChangeHealth(value, maxValue));
    }

    private IEnumerator ChangeHealth(float value, float maxValue)
    {
        while(_bar.fillAmount > value / maxValue)
        {
            _bar.fillAmount = Mathf.MoveTowards(_bar.fillAmount, value / maxValue, _speed * Time.deltaTime);
            yield return null;
        }

        _changeHealthCoroutine = null;
    }
}
