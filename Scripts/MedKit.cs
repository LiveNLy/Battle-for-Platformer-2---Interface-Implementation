using UnityEngine;

public class MedKit : PickableItem
{
    [SerializeField] private float _healAmount = 60;

    public float HealingChar()
    {
        gameObject.SetActive(false);
        return _healAmount;
    }

    protected override void ActionAfterHit()
    {
        gameObject.SetActive(false);
    }
}