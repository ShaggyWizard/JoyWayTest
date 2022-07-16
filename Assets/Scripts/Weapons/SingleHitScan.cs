using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleHitScan
{
    public delegate void OnHitDelegate(RaycastHit hitInfo);
    public OnHitDelegate OnHit;


    public void Shoot(Transform aimer, float distance = float.MaxValue)
    {
        if (Physics.Raycast(aimer.position, aimer.forward, out RaycastHit hitInfo, distance))
        {
            OnHit(hitInfo);
        }
    }
} 