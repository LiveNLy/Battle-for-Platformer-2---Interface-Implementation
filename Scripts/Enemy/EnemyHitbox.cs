using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    [SerializeField] private float _damage = 30;

    public float GetDamage() {  return _damage; }
}