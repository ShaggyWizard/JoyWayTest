using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorCharacter : MonoBehaviour, IRotator
{
    [Header("Options")]
    [SerializeField, Range(0f, 1000f)] private float _turnSpeed = 10f;
    [SerializeField, Range(0, 180f)] private float _maxDownwardAngle = 90f;
    [SerializeField, Range(0, 180f)] private float _maxUpwardAngle = 90f;
    [Header("Transforms")]
    [SerializeField] private Transform _horizontalTransform;
    [SerializeField] private Transform _verticalTransform;


    private float _xRotation;
    private float _yRotation;


    public void Rotate(Vector3 vector)
    {
        _yRotation += vector.x * _turnSpeed * Time.deltaTime;

        _xRotation -= vector.y * _turnSpeed * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -_maxUpwardAngle, _maxDownwardAngle);


        _verticalTransform.localRotation = Quaternion.Euler(_xRotation,0,0);
        _horizontalTransform.localRotation = Quaternion.Euler(0, _yRotation, 0);
    }


    private void OnValidate()
    {
        if (_horizontalTransform == null) _horizontalTransform = transform;
        if (_verticalTransform == null) _verticalTransform = transform;
    }
}
