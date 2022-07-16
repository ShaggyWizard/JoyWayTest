using UnityEngine;
public class FPSPlayerInput : MonoBehaviour, IMoveSignal, IRotateSignal
{
    public Vector3 MoveVector => _moveInput;
    public Vector3 Rotation => _mouseInput;


    private Vector3 _moveInput;
    private Vector3 _mouseInput;


    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        _moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        _mouseInput = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);
    }
}