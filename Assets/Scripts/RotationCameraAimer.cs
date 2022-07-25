using UnityEngine;

public class RotationCameraAimer : MonoBehaviour, IRotateInput
{
    private Transform _target;


    public Vector3 Rotation => _target == null ? transform.eulerAngles : Quaternion.LookRotation(_target.position - transform.position).eulerAngles;


    private void Awake()
    {
        _target = Camera.main.transform;
    }
}