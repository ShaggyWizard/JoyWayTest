using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour, IHealth, IRespawn, IDeath
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;


    private Collider[] _colliders;


    public event Action OnRespawn;
    public event Action OnDeath;


    public float Health
    {
        get { return _health; }
        private set { _health = value > 0f ? value : 0f; }
    }


    private void Awake()
    {
        _colliders = GetComponents<Collider>();
        Health = _maxHealth;
    }


    public void ModifyHealth(float modifyer)
    {
        Health += modifyer;

        if (Health == 0) { Die(); }
    }
    public void Die()
    {
        foreach (var collider in _colliders) { collider.enabled = false; }
        OnDeath?.Invoke();
    }
    public void Respawn()
    {
        foreach (var collider in _colliders) { collider.enabled = true; }
        Health = _maxHealth;
        OnRespawn?.Invoke();
    }
}
