using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private float _damage = 999;

    public float DamageGiven() { return _damage; }
}