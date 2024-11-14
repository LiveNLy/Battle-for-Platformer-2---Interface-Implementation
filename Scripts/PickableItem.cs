using UnityEngine;

public abstract class PickableItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DeathTrigger deathTrigger) || collision.gameObject.TryGetComponent(out EnemyHitbox enemyHitbox))
        {
            ActionAfterHit();
        }
    }

    protected abstract void ActionAfterHit();
}