using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTimeStatusBehavior : MonoBehaviour
{
    public string Name { get; private set; }
    public bool CanStack { get; private set; }


    private LinkedList<EffectOverTime> _effects;
    private int _expiredCount;
    private IHealth _target;
    private float _damage;


    private void Awake()
    {
        _effects = new LinkedList<EffectOverTime>();
    }
    private void Update()
    {
        foreach (var effect in _effects)
        {
            effect.Update(Time.deltaTime);
        }
        while (_expiredCount > 0)
        {
            _effects.RemoveFirst();
            _expiredCount--;
        }
    }


    public void Init(string name, float duration, float tickRate, float damage, bool canStack, bool resetTimer)
    {
        if (!TryGetComponent(out _target))
        {
            DestroyMe();
            return;
        }
        if (_effects.Count == 0)
        {
            Name = name;
            CanStack = canStack;
            _damage = damage;
        }
        if (_effects.Count == 0 || CanStack)
        {
            Add(duration, tickRate);
        }
        if (resetTimer)
        {
            foreach (var effect in _effects)
            {
                effect.SetTime(duration);
            }
        }
    }

    private void Add(float duration, float tickRate)
    {
        EffectOverTime effect = new EffectOverTime(duration, tickRate);
        effect.OnTick += DealDamage;
        effect.OnTimerEnd += RemoveStack;
        _effects.AddLast(effect);
    }


    private void DealDamage()
    {
        _target.ModifyHealth(-_damage);
    }
    private void RemoveStack()
    {
        _expiredCount++;
    }
    private void DestroyMe()
    {
        Destroy(this);
    }
}
