using UnityEngine;

public class LateMotor : MonoBehaviour
{
    private IMover _mover;
    private IRotator _rotator;
    private IMoveInput _moveInput;
    private IRotateInput _rotateInput;


    private void Awake()
    {
        _mover = GetComponent<IMover>();
        _rotator = GetComponent<IRotator>();
        _moveInput = GetComponent<IMoveInput>();
        _rotateInput = GetComponent<IRotateInput>();
    }
    private void LateUpdate()
    {
        if (_moveInput != null) { _mover?.Move(_moveInput.MoveVector); }
        if (_rotateInput != null) { _rotator?.Rotate(_rotateInput.Rotation); }
    }
}
