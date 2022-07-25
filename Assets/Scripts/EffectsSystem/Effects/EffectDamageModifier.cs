using UnityEngine;


[CreateAssetMenu(menuName = "Effect/Damage Modifier")]
public class EffectDamageModifier : AbstractEffect, IModifyEffect, IContinious, IStackable
{
    [Header("Damage Modifier options")]
    [SerializeField] private int _maxStacks;
    [SerializeField] private AbstractEffect[] _effectSource;
    [SerializeField] private float modifier;

    public int MaxStacks => _maxStacks;

    public void ModifyEffect(AbstractEffect effect)
    {
        if (!(effect is IDamage)) { return; }
        foreach (var source in _effectSource)
        {
            if (effect.guid == source.guid) { ((IDamage)effect).Damage += modifier; }
        }

    }
    public override void Init(IEffectable target) { }
    public void OnEnd() { }


    private void OnValidate()
    {
        _maxStacks = _maxStacks < 0 ? 0 : _maxStacks;
    }
}