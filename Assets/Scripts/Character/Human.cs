using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour, IHealth
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;


    public float Health
    {
        get { return _health; }
        private set { _health = value > 0f ? value : 0f; }
    }


    public void ModifyHealth(float modifyer)
    {
        Debug.Log($"{Health} {modifyer}");
        Health += modifyer;
    }

    private void OnEnable()
    {
        Health = _maxHealth;
    }
}
