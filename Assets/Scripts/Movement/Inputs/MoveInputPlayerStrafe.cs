using UnityEngine;


public class MoveInputPlayerStrafe : MonoBehaviour, IMoveInput
{
    public Vector3 MoveVector => new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
}