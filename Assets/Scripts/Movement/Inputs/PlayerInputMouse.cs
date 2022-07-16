using UnityEngine;
public class PlayerInputMouse : MonoBehaviour, IRotateSignal
{
    public Vector3 Rotation => _rotation;

    private Vector3 _rotation;


    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        _rotation = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);
    }
}