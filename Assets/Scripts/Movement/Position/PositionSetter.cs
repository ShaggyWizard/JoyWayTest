using UnityEngine;

public class PositionSetter : MonoBehaviour, IMover
{
    [SerializeField] private Transform _targetTransform;


    private void OnValidate()
    {
        if (_targetTransform == null) _targetTransform = transform;
    }


    public void Move(Vector3 direction)
    {
        transform.position = direction;
    }
}
