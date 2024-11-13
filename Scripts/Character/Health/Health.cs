using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float MaxHealthValue = 150;
    [SerializeField] protected float _healthValue = 150;

    public event Action<float, float> SendInfo;
    public event Action LostHealth;

    private void Start()
    {
        SendHealthInfo();
    }

    public void LoseHealth(float damage)
    {
        if (_healthValue > 0 && damage > 0)
            _healthValue -= Mathf.Clamp(damage, 0, _healthValue);

        if (_healthValue <= 0)
            HealthLost();

        SendHealthInfo();
    }

    public void Heal(float heal)
    {
        if (_healthValue < MaxHealthValue && heal > 0)
            _healthValue += Mathf.Clamp(heal, 0, MaxHealthValue - _healthValue);

        SendHealthInfo();
    }

    private void HealthLost()
    {
        LostHealth?.Invoke();

        Heal(MaxHealthValue);
    }

    private void SendHealthInfo()
    {
        SendInfo?.Invoke(_healthValue, MaxHealthValue);
    }
}