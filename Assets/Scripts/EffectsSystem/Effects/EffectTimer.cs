using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Temporary")]
public class EffectTimer : AbstractEffect, IUpdateable, IStackable, IResetTimer
{
    [Header("Temporary options")]
    [SerializeField] private float _duration;
    [SerializeField] private int _maxStacks;
    [SerializeField] private float _tickRate;
    [SerializeField] private AbstractEffect[] _effectsOnStart;
    [SerializeField] private AbstractEffect[] _effectsOnOnTick;
    [SerializeField] private AbstractEffect[] _effectsOnEnd;

    private Timer _timer;
    private IEffectable _target;
    

    public int MaxStacks { get { return _maxStacks; } }


    public override void Init(IEffectable target)
    {
        _target = target;

        EffectOnStart();

        _timer = new Timer(_duration, _tickRate);
        _timer.OnTick += EffectOnTick;
        _timer.OnTimerEnd += EffectOnEnd;
    }
    public bool TryUpdate(float deltaTime)
    {
        return _timer.TryUpdate(deltaTime);
    }
    public void OnEnd()
    {
        _timer.End();
        EffectsOnStartEnd();
    }
    public void ResetTimer()
    {
        _timer.Set(_duration);
    }
    public string DebugMessage()
    {
       return $"[{name}] progress:{_timer.Progress}";
    }


    private void OnValidate()
    {
        _maxStacks = _maxStacks < 0 ? 0 : _maxStacks;
    }


    private void EffectOnStart() { foreach (var effect in _effectsOnStart) { _target.AddEffect(Instantiate(effect)); } }
    private void EffectsOnStartEnd() { foreach (var effect in _effectsOnStart) { _target.RemoveEffect(effect); } }
    private void EffectOnTick() { foreach (var effect in _effectsOnOnTick) { _target.AddEffect(Instantiate(effect)); } }
    private void EffectOnEnd() { foreach (var effect in _effectsOnEnd) { _target.AddEffect(Instantiate(effect)); } }
}