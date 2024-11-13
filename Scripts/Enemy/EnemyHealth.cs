using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private EnemyHurtBox _enemyHurtBox;

    private void OnEnable()
    {
        _enemyHurtBox.LosedHealth += LoseHealth;
    }

    private void OnDisable()
    {
        _enemyHurtBox.LosedHealth -= LoseHealth;
    }

    public float MaxHealthReturn()
    {
        return MaxHealthValue;
    }
}