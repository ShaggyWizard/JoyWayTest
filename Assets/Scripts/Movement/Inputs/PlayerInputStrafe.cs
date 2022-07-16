using UnityEngine;
public class PlayerInputStrafe : MonoBehaviour, IMoveSignal
{
    public Vector3 MoveVector => _inputVector;
    private Vector3 _inputVector;


    private void Update()
    {
        _inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }
}