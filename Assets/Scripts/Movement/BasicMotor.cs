using UnityEngine;

public class BasicMotor : MonoBehaviour
{
    private IMover _mover;
    private IRotator _rotator;
    private IMoveSignal _moveInput;
    private IRotateSignal _rotateInput;


    private void Awake()
    {
        _mover = GetComponent<IMover>();
        _rotator = GetComponent<IRotator>();
        _moveInput = GetComponent<IMoveSignal>();
        _rotateInput = GetComponent<IRotateSignal>();
    }
    private void Update()
    {
        if (_moveInput != null) { _mover?.Move(_moveInput.MoveVector); }
        if (_rotateInput != null) { _rotator?.Rotate(_rotateInput.Rotation); }
    }
}
