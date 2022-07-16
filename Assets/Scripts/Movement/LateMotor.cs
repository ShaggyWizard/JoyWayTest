using UnityEngine;

public class LateMotor : MonoBehaviour
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
    private void LateUpdate()
    {
        _mover.Move(_moveInput.MoveVector);
        _rotator.Rotate(_rotateInput.Rotation);
    }
}
