using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorBehavior : MonoBehaviour
{
    [SerializeField] private Transform _aimer;
    [SerializeField, Range(0,10f)] private float _interactionRadius;


    private SingleHitScan _hitScan;


    public void Interact()
    {

    }


    private void Awake()
    {
        _hitScan = new SingleHitScan();

        if (_aimer == null) { _aimer = transform; }
    }
}
