using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _damage = 45f;

    public float GiveDamage()
    {
        return _damage;
    }
}
