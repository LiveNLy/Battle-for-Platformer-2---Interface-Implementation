using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private float _damage = 999;

    public float GetDamage() { return _damage; }
}