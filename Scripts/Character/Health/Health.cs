using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float MaxHealthValue = 150;
    [SerializeField] protected float HealthValue = 150;

    public event Action<float, float> SendInfo;
    public event Action LostHealth;

    private void Start()
    {
        SendHealthInfo();
    }

    public void LoseHealth(float damage)
    {
        if (HealthValue > 0 && damage > 0)
            HealthValue -= Mathf.Clamp(damage, 0, HealthValue);

        if (HealthValue <= 0)
            HealthLost();

        SendHealthInfo();
    }

    public void Heal(float heal)
    {
        if (HealthValue < MaxHealthValue && heal > 0)
            HealthValue += Mathf.Clamp(heal, 0, MaxHealthValue - HealthValue);

        SendHealthInfo();
    }

    private void HealthLost()
    {
        LostHealth?.Invoke();

        Heal(MaxHealthValue);
    }

    private void SendHealthInfo()
    {
        SendInfo?.Invoke(HealthValue, MaxHealthValue);
    }
}