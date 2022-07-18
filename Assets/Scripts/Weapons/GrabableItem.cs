using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableItem : MonoBehaviour, IGrabable
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private Collider[] _allColliders;

    public event Action OnPickUpEvent;
    public event Action OnDropEvent;


    private IMotor _motor;
    private Transform _originalParent;
    private Rigidbody _rigidbody;


    private void Awake()
    {
        _motor = GetComponent<IMotor>();
        _rigidbody = GetComponent<Rigidbody>();
        _originalParent = transform.parent;
        _allColliders = GetComponentsInChildren<Collider>();
    }


    public void OnPickUp()
    {
        _motor?.Off();
        OnPickUpEvent?.Invoke();
        foreach (var collider in _allColliders)
        {
            collider.enabled = false;
        }
        if (_rigidbody != null)
        {
            _rigidbody.isKinematic = true;
            _rigidbody.detectCollisions = false;
        }
    }
    public void OnDrop()
    {
        _motor?.On();
        OnDropEvent?.Invoke();
        foreach (var collider in _allColliders)
        {
            collider.enabled = true;
        }
        if (_rigidbody != null)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.detectCollisions = true;
        }

        transform.parent = _originalParent;
    }
    public void SetPosition(Transform slot)
    {
        transform.parent = slot;
        transform.localPosition = _offset;
        transform.localEulerAngles = _rotation;
    }
}
