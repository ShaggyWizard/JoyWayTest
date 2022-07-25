using UnityEngine;

[CreateAssetMenu(menuName = "Effect/PurgeStack")]
public class EffectPurgeStack : AbstractEffect
{
    [Header("Purge options")]
    [SerializeField] private AbstractEffect _purging;


    public override void Init(IEffectable target)
    {
        var effects = target.Effects;
        for (int i = 0; i < effects.Count; i++)
        {
            //Removes oldest stack
            if (effects[i].guid == _purging.guid)
            {
                target.RemoveEffect(effects[i]);
                break;
            }
        }
    }
}