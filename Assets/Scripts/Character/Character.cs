using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IHealth
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;

    public event Action OnDeath;

    public float Health
    {
        get { return _health; }
        private set { _health = value > 0f ? value : 0f; }
    }


    private void OnEnable()
    {
        Health = _maxHealth;
        OnDeath += Death;
    }
    private void OnDisable()
    {
        OnDeath -= Death;
    }


    public void ModifyHealth(float modifyer)
    {
        Health += modifyer;

        if (Health == 0) { OnDeath.Invoke(); }
    }


    private void Death()
    {
        Destroy(gameObject);
    }
}
