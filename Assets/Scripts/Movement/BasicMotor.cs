using UnityEngine;


public class BasicMotor : MonoBehaviour, IMotor
{
    private IMover _mover;
    private IRotator _rotator;
    private IMoveInput _moveInput;
    private IRotateInput _rotateInput;


    public void On() { enabled = true; }
    public void Off() { enabled = false; }


    private void Awake()
    {
        _mover = GetComponent<IMover>();
        _rotator = GetComponent<IRotator>();
        _moveInput = GetComponent<IMoveInput>();
        _rotateInput = GetComponent<IRotateInput>();
    }
    private void FixedUpdate()
    {
        if (_moveInput != null) { _mover?.Move(_moveInput.MoveVector); }
    }
    private void Update()
    {
        if (_rotateInput != null) { _rotator?.Rotate(_rotateInput.Rotation); }
    }
}
