using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Purge")]
public class EffectPurge : AbstractEffect
{
    [Header("Purge options")]
    [SerializeField] private AbstractEffect[] _purging;


    public override void Init(IEffectable target)
    {
        var effects = target.Effects;
        for (int i = 0; i < effects.Count; i++)
        {
            foreach (var purge in _purging)
            {
                if (effects[i].guid == purge.guid)
                {
                    target.RemoveEffect(effects[i]);
                    i--;
                    break;
                }
            }
        }
    }
}