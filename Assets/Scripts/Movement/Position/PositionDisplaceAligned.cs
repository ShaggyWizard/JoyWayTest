using UnityEngine;

public class PositionDisplaceAligned : MonoBehaviour, IMover
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField, Range(0f, 100f)] float _moveSpeed;


    private void OnValidate()
    {
        if (_targetTransform == null) _targetTransform = transform;
    }


    public void Move(Vector3 direction)
    {
        Vector3 movement = Vector3.Normalize(direction) * _moveSpeed;
        Vector3 displacement = transform.rotation * movement;
        transform.position += displacement * Time.deltaTime;
    }
}
