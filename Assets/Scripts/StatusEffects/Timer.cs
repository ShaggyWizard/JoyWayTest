using System;

public class Timer
{
    public event Action OnTimerEnd;


    private float _duration;
    private float _remainingTime;


    public float RemainingTime
    {
        get { return _remainingTime; }
        private set { _remainingTime = value > 0f ? value : 0f; }
    }
    public float Progress
    {
        get { return 1f - (_remainingTime / _duration); }
    }

    public Timer(float time)
    {
        RemainingTime = time;
        _duration = RemainingTime;
    }


    public void SetTime(float time)
    {
        RemainingTime = time;
    }
    public void Update(float deltaTime)
    {
        if (_remainingTime == 0f) { return; }

        RemainingTime -= deltaTime;

        CheckIfDone();
    }


    private void CheckIfDone()
    {
        if (_remainingTime > 0f) { return; }

        OnTimerEnd?.Invoke();
    }
}
