using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableItem : MonoBehaviour, IGrabable
{
    [SerializeField] Vector3 offset;
    [SerializeField] Vector3 rotation;

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
    }


    public void OnPickUp()
    {
        _motor?.Off();
        OnPickUpEvent?.Invoke();
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
        transform.localPosition = offset;
        transform.localEulerAngles = rotation;
    }
}
