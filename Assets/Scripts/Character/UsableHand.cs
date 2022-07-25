using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableHand : MonoBehaviour, IUsable, IDisusable, IAimable
{
    [SerializeField] private float _radius;
    [SerializeField] private Transform _aimer;
    [SerializeField] private Transform _slotPosition;


    private IGrabable _itemGrabable;
    private IUsable _itemUsable;
    private IDisusable _itemDisusable;
    private HitScan _hitScan;


    public event Action OnUse;
    public event Action OnDisuse;


    private void Awake()
    {
        _hitScan = new HitScan();
        _hitScan.OnHit += TryGrab;

        if (_aimer == null) { _aimer = transform; }
    }


    public void Use()
    {
        _itemUsable?.Use();
        OnUse?.Invoke();
    }
    public void Disuse()
    {
        _itemDisusable?.Disuse();
        OnDisuse?.Invoke();
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
    public void SetAimer(Transform aimer) { _aimer = aimer; }


    private void Grab() { _hitScan.Shoot(_aimer, _radius); }
    private void Drop()
    {
        _itemGrabable.OnDrop();
        _itemGrabable = null;
        _itemUsable = null;
    }
    private void TryGrab(Transform target)
    {
        if (target.TryGetComponent(out IGrabable grabable))
        {
            _itemGrabable = grabable;
            _itemUsable = target.GetComponent<IUsable>();
            _itemDisusable = target.GetComponent<IDisusable>();

            if (target.TryGetComponent(out IAimable itemAimable)) 
            {
                itemAimable.SetAimer(_aimer);
            }

            grabable.OnPickUp();
            grabable.SetPosition(_slotPosition);
        }
    }
}