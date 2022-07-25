using UnityEngine;


[CreateAssetMenu(menuName = "Effect/Damage")]
public class EffectDamage : AbstractEffect, IDamage
{
    [Header("Damage options")]
    public float damage;

    public float Damage { get { return damage; } set { damage = value; } }

    public override void Init(IEffectable target)
    {
        if (target is IDamageable) { ((IDamageable)target).TakeDamage(damage); }
    }
}