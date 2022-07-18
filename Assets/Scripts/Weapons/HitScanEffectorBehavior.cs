using System;
using UnityEngine;

public class HitScanEffectorBehavior : MonoBehaviour, IUsable, IAimable
{
    [SerializeField] private Transform _aimer;


    public event Action OnUse;


    private SingleHitScan _hitScan;


    private void Awake()
    {
        _hitScan = new SingleHitScan();

        foreach (var effect in GetComponents<IEffector>())
        {
            _hitScan.OnHit += effect.Effect;
        }

        if (_aimer == null) { _aimer = transform; }
    }


    public void SetAimer(Transform newAimer)
    {
        _aimer = newAimer;
    }
    public void Use()
    {
        _hitScan.Shoot(_aimer);
        OnUse?.Invoke();
    }
}
