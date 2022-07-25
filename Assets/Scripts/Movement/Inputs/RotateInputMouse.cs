using UnityEngine;


public class RotateInputMouse : MonoBehaviour, IRotateInput
{
    public Vector3 Rotation => new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"), 0f);

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}