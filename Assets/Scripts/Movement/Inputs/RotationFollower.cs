using UnityEngine;

public class RotationFollower : MonoBehaviour, IRotateInput
{
    [SerializeField] private Transform _target;


    public Vector3 Rotation => _target == null ? transform.eulerAngles : _target.eulerAngles;
}