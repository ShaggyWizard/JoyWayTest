using System;


public class EffectOverTime
{
    public event Action OnTick;
    public event Action OnTimerEnd;


    private float _tickRate;
    private float _tickTimer;
    private Timer _timer;

    public EffectOverTime(float duration, float tickRate)
    {
        _timer = new Timer(duration);
        _tickRate = tickRate;
        _tickTimer = _tickRate;
        _timer.OnTimerEnd += OnEffectEnd;
    }


    public void Update(float deltaTime)
    {
        _timer.Update(deltaTime);

        _tickTimer -= deltaTime;

        CheckForEffect();
    }
    private void CheckForEffect()
    {
        if (_tickTimer > 0f) { return; }

        OnTick?.Invoke();

        _tickTimer += _tickRate;
    }
    private void OnEffectEnd()
    {
        OnTimerEnd?.Invoke();
    }
}
