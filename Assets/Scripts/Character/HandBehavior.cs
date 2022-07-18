using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehavior : MonoBehaviour, IUsable, IAimable
{
    [SerializeField] private float _radius;
    [SerializeField] private Transform _aimer;
    [SerializeField] private Transform _slotPosition;


    private IGrabable _itemGrabable;
    private IUsable _itemUsable;
    private SingleHitScan _hitScan;


    public event Action OnUse;


    private void Awake()
    {
        _hitScan = new SingleHitScan();
        _hitScan.OnHit += TryGrab;

        if (_aimer == null) { _aimer = transform; }
    }


    public void Use()
    {
        _itemUsable?.Use();
        OnUse?.Invoke();
    }
    public void GrabOrDrop()
    {
        if (_itemGrabable == null)
        {
            Grab();
        }
        else
        {
            Drop();
        }
    }
    public void SetAimer(Transform aimer)
    {
        _aimer = aimer;
    }


    private void Grab()
    {
        _hitScan.Shoot(_aimer, _radius);
    }
    private void Drop()
    {
        _itemGrabable.OnDrop();
        _itemGrabable = null;
        _itemUsable = null;
    }
    private void TryGrab(RaycastHit hitInfo)
    {
        if (hitInfo.transform.TryGetComponent(out IGrabable target))
        {
            _itemGrabable = target;

            if (hitInfo.transform.TryGetComponent(out IUsable itemUsable))
            {
                _itemUsable = itemUsable;
            }

            if (hitInfo.transform.TryGetComponent(out IAimable itemAimable)) 
            {
                itemAimable.SetAimer(_aimer);
            }

            target.OnPickUp();
            target.SetPosition(_slotPosition);
        }
    }
}