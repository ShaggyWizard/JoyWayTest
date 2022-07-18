using System;
using UnityEngine;

public class Character : MonoBehaviour, IHealth, IRespawn, IDeath
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;


    public event Action OnDeath;
    public event Action OnRespawn;


    public float Health
    {
        get { return _health; }
        private set { _health = value > 0f ? value : 0f; }
    }


    public void ModifyHealth(float modifyer)
    {
        Health += modifyer;

        if (Health == 0) { Die(); }
    }
    public void Respawn()
    {
        OnRespawn.Invoke();
    }
    public void Die()
    {
        OnDeath.Invoke();
        Destroy(gameObject);
    }


    private void OnEnable()
    {
        Health = _maxHealth;
    }
}
