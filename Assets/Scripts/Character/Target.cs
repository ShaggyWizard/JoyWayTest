using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IHealth
{
    [SerializeField] private float _health;


    public float Health
    {
        get { return _health; }
        private set { _health = value > 0f ? value : 0f; }
    }


    public void ModifyHealth(float modifyer)
    {
        if (modifyer < 0)
            Debug.Log($"{name} took {-modifyer} damage");
        Health += modifyer;
    }
}
