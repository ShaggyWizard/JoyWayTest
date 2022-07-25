using System;
using System.Collections.Generic;
using UnityEngine;


public class UsableOnHitEffector : MonoBehaviour, IUsable, IAimable
{
    [SerializeField] private Transform _aimer;
    [SerializeField] private AbstractEffect[] _effects;


    public event Action OnUse;


    private HitScan _hitScan;


    public void SetAimer(Transform newAimer)
    {
        _aimer = newAimer;
    }
    public void Use()
    {
        OnUse?.Invoke();
    }


    private void Awake()
    {
        _hitScan = new HitScan();

        _hitScan.OnHit += TryEffect;

        if (_aimer == null) { _aimer = transform; }

        OnUse += Shoot;
    }

    
    private void TryEffect(Transform target)
    {
        if (!target.TryGetComponent(out IEffectable effectable)) { return; }

        foreach (var effect in _effects) { effectable.AddEffect(Instantiate(effect)); }
    }
    private void Shoot() { _hitScan.Shoot(_aimer); }
}
