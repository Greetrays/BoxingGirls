using UnityEngine;

public class AnimationCorrector : MonoBehaviour
{
    [SerializeField] private Transform _animatorCorrectorPoint;
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
        if (gameObject.TryGetComponent(out MotionCorrector motionCorrector))
        {
            motionCorrector.enabled = false;
        }
        
        transform.position = _animatorCorrectorPoint.transform.position;
    }
}
