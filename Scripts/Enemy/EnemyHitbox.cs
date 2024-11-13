using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    [SerializeField] private float _damage = 30;

    public float DamageGiven() {  return _damage; }
}