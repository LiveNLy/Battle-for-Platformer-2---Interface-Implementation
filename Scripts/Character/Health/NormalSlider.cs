using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class NormalSlider : HealthView
{
    protected Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        transform.position = _health.transform.position;
    }

    protected override void ShowHealth(float healthCount, float maxHealthValue)
    {
        _slider.maxValue = maxHealthValue;
        _slider.value = healthCount;
    }
}