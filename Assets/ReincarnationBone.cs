using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReincarnationBone : MonoBehaviour
{
    private Quaternion _localRotationOrigin;
    private Vector3 _localPositionOrigin;

    private Quaternion _brokenRotation;
    private Vector3 _brokenPosition;

    private Vector3 _velocity;
    private float _degreesDelta;
    private Collider _collider;
    private Rigidbody _rigidBody;


    private void Awake()
    {
        if (!TryGetComponent(out _collider)) { Destroy(this); }
        if (!TryGetComponent(out _rigidBody)) { _rigidBody = gameObject.AddComponent<Rigidbody>(); }

        _collider.enabled = false;

        _rigidBody.isKinematic = true;
        _rigidBody.detectCollisions = false;

        _localRotationOrigin = transform.localRotation;
        _localPositionOrigin = transform.localPosition;
    }

    public void Lerp(float time)
    {
        if (time < 1)
        {
            transform.localRotation = Quaternion.Lerp(_brokenRotation, _localRotationOrigin, time);
            transform.localPosition = Vector3.Lerp(_brokenPosition, _localPositionOrigin, time);
        }
        else
        {
            _collider.enabled = false;
            _rigidBody.isKinematic = true;
            _rigidBody.detectCollisions = false;

            transform.localRotation = _localRotationOrigin;
            transform.localPosition = _localPositionOrigin;
        }

    }
    public void Break()
    {
        _collider.enabled = true;
        _rigidBody.isKinematic = false;
        _rigidBody.detectCollisions = true;
    }

    public void Reincarnate()
    {
        _brokenRotation = transform.localRotation;
        _brokenPosition = transform.localPosition;
    }
}
