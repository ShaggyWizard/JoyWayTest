using UnityEngine;

public class CloneRotation : MonoBehaviour, IRotateSignal
{
    [SerializeField] private Transform _target;


    public Vector3 Rotation => _target == null ? transform.eulerAngles : _target.eulerAngles;
}