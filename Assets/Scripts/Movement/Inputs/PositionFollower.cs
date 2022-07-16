using UnityEngine;
public class PositionFollower : MonoBehaviour, IMoveSignal
{
    [SerializeField] private Transform _target;


    public Vector3 MoveVector => _target == null ? transform.position : _target.position;

}