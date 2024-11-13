using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Health _characterHealth;

    public event Action CoinTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            CoinTaken?.Invoke();
        }
        else if (collision.gameObject.TryGetComponent(out MedKit medKit))
        {
            _characterHealth.Heal(medKit.HealingChar());
        }
        else if (collision.gameObject.TryGetComponent(out DeathTrigger deathTrigger))
        {
            _characterHealth.LoseHealth(deathTrigger.DamageGiven());
        }
        else if (collision.gameObject.TryGetComponent(out EnemyHitbox enemyHitbox))
        {
            _characterHealth.LoseHealth(enemyHitbox.DamageGiven());
        }
    }
}
