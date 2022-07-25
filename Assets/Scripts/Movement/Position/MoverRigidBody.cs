using UnityEngine;


public class MoverRigidBody : MonoBehaviour, IMover
{
    [SerializeField] private Rigidbody _targetRigidBody;
    [SerializeField, Range(0f, 100f)] float _moveSpeed;
    [SerializeField, Range(0f, 100f)] float _groundDrag;


    public void Move(Vector3 direction)
    {
        _targetRigidBody.AddForce(_targetRigidBody.transform.rotation * direction.normalized * _moveSpeed, ForceMode.Force);
    }


    private void OnValidate()
    {
        if (_targetRigidBody == null) _targetRigidBody = GetComponent<Rigidbody>();
        _targetRigidBody.drag = _groundDrag;
    }
    private void Start()
    {
        _targetRigidBody.freezeRotation = true;
        _targetRigidBody.drag = _groundDrag;
    }
}
