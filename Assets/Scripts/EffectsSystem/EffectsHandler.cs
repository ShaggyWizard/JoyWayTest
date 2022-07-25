using System.Collections.Generic;
using System.Linq;

public class EffectsHandler : IEffectable
{
    public List<AbstractEffect> Effects { get; private set; }


    private IEffectable _target;
    private List<IUpdateable> _updateables = new List<IUpdateable>();
    private List<IModifyEffect> _modifiers = new List<IModifyEffect>();
    private Stack<AbstractEffect> _newEffects = new Stack<AbstractEffect>();

    public EffectsHandler(IEffectable target)
    {
        _target = target;
        Effects = new List<AbstractEffect>();
    }

    
    public void AddEffect(AbstractEffect newEffect)
    {
        if (!newEffect.Compatible(this)) return;

        _newEffects.Push(newEffect);
    }
    public void ModifyEffect(AbstractEffect newEffect)
    {
        foreach (var modifier in _modifiers) { modifier.ModifyEffect(newEffect); }
    }
    public void RemoveEffect(AbstractEffect removeEffect)
    {
        var match = Effects.Find(effect => effect.guid == removeEffect.guid);
        if (match == null) { return; }
        Effects.Remove(match);
        if (match is IUpdateable) { _updateables.Remove((IUpdateable)match); }
        if (match is IContinious) { ((IContinious)match).OnEnd(); }
        if (match is IModifyEffect) { _modifiers.Remove((IModifyEffect)match); }

    }
    public void Update(float deltaTime)
    {
        InitNewEffect();
        TryUpdateEffects(deltaTime);
    }


    private void InitNewEffect()
    {
        while (_newEffects.Count > 0)
        {
            var newEffect = _newEffects.Pop();

            ModifyEffect(newEffect);

            if (newEffect is IResetTimer)
            {
                var timers = Effects.Where(effect => effect.guid == newEffect.guid);
                foreach (var timer in timers) { ((IResetTimer)timer).ResetTimer(); }
            }

            int maxStacks = newEffect is IStackable ? ((IStackable)newEffect).MaxStacks : 0;
            if (maxStacks != 0)
            {
                var count = Effects.Where(effect => effect.guid == newEffect.guid).Count();
                if (count >= maxStacks) { return; }
            }

            newEffect.Init(_target);

            if (newEffect is IContinious)
            {
                Effects.Add(newEffect);
                if (newEffect is IUpdateable) { _updateables.Add((IUpdateable)newEffect); }
                if (newEffect is IModifyEffect) { _modifiers.Add((IModifyEffect)newEffect); }
            }
        }
    }
    private void TryUpdateEffects(float deltaTime)
    {
        for (int i = 0; i < _updateables.Count; i++)
        {
            if (!_updateables[i].TryUpdate(deltaTime))
            {
                RemoveEffect((AbstractEffect)_updateables[i]);
                i--;
            }
        }
    }
}