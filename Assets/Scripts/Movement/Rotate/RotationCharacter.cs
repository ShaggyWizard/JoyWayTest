using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCharacter : MonoBehaviour, IRotator
{
    [Header("Options")]
    [SerializeField, Range(0f, 1000f)] private float _turnSpeed = 10f;
    [SerializeField, Range(0, 180f)] private float _maxDownwardAngle = 90f;
    [SerializeField, Range(0, 180f)] private float _maxUpwardAngle = 90f;
    [Header("Transforms")]
    [SerializeField] private Transform _horizontalTransform;
    [SerializeField] private Transform _verticalTransform;


    private float _verticalRotation;


    private void OnValidate()
    {
        if (_horizontalTransform == null) _horizontalTransform = transform;
        if (_verticalTransform == null) _verticalTransform = transform;
    }
    public void Rotate(Vector3 vector)
    {
        Vector2 inputRotation = vector * _turnSpeed * Time.deltaTime;

        Vector3 rotation = Vector3.up * inputRotation.x;
        _horizontalTransform.localEulerAngles += rotation;

        _verticalRotation -= inputRotation.y;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -_maxUpwardAngle, _maxDownwardAngle);
        _verticalTransform.localEulerAngles = new Vector3(_verticalRotation, _verticalTransform.localEulerAngles.y, _verticalTransform.localEulerAngles.z);
    }
}
