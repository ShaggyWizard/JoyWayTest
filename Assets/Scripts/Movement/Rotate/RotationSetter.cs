using UnityEngine;

public class RotationSetter : MonoBehaviour, IRotator
{
    [SerializeField] private Transform _targetTransform;


    private void OnValidate()
    {
        if (_targetTransform == null) _targetTransform = transform;
    }


    public void Rotate(Vector3 rotation)
    {
        transform.eulerAngles = rotation;
    }
}
