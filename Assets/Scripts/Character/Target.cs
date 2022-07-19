using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    public event OnDamageDeleagate OnDamage;

    public void TakeDamage(float damage)
    {
        OnDamage?.Invoke(damage);
    }
}
