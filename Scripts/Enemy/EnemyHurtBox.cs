using System;
using UnityEngine;

public class EnemyHurtBox : MonoBehaviour
{
    public event Action<float> LosedHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Character character))
        {
            LosedHealth?.Invoke(character.GiveDamage());
        }
    }
}