using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTimeBehavior : MonoBehaviour
{
    private EffectOverTime _timer;
    private float _damage;
    private IHealth _target;


    private void Update()
    {
        _timer.Update(Time.deltaTime);
    }


    public void Init(float duration, float tickRate, float damage)
    {
        if (!TryGetComponent(out _target))
        {
            DestroyMe();
            return;
        }
        _damage = damage;
        _timer = new EffectOverTime(duration, tickRate);
        _timer.OnTick += DealDamage;
        _timer.OnTimerEnd += DestroyMe;
    }


    private void DealDamage()
    {
        _target.ModifyHealth(-_damage);
    }
    private void DestroyMe()
    {
        Destroy(this);
    }
}
