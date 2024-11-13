using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothSlider : NormalSlider
{
    [SerializeField, Range(0, 1)] private float _sliderSpeed = 0.3f;

    private Coroutine _coroutine;
    private WaitForEndOfFrame wait = new WaitForEndOfFrame();

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    protected override void ShowHealth(float healthCount, float maxHealthValue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothHealthChanging(healthCount, maxHealthValue));
    }

    private IEnumerator SmoothHealthChanging(float healthCount, float maxHealthValue)
    {
        _slider.maxValue = maxHealthValue;

        while (_slider.value != healthCount)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, healthCount, _sliderSpeed);

            yield return wait;
        }
    }
}