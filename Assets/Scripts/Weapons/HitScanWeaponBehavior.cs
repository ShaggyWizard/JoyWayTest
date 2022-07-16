using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanWeaponBehavior : MonoBehaviour, IUsable, IAimable
{
    [SerializeField] private Transform _aimer;
    [SerializeField] private float _damage;
    private SingleHitScan _hitScan;


    private void Awake()
    {
        _hitScan = new SingleHitScan();
        _hitScan.OnHit += TryDealDamage;

        if (_aimer == null) { _aimer = transform; }
    }


    public void SetAimer(Transform newAimer)
    {
        _aimer = newAimer;
    }
    public void Use()
    {
        _hitScan.Shoot(_aimer);
    }


    private void TryDealDamage(RaycastHit hitInfo)
    {
        Debug.Log($"Trying to damage {hitInfo.transform.name}");
        if (hitInfo.transform.TryGetComponent(out IHealth target))
        {
            target.ModifyHealth(-_damage);
        }
    }
}
