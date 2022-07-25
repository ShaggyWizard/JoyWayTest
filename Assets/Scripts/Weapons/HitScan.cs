using UnityEngine;

public class HitScan
{
    public EffectTargetDelegate OnHit;


    public void Shoot(Transform aimer, float distance = float.MaxValue)
    {
        if (Physics.Raycast(aimer.position, aimer.forward, out RaycastHit hitInfo, distance))
        {
            OnHit?.Invoke(hitInfo.transform);
        }
    }
} 