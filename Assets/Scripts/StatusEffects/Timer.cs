using System;

public class Timer
{
    public event Action OnTimerEnd;


    private float _remainingTime;


    public float RemainingTime
    {
        get { return _remainingTime; }
        private set { _remainingTime = value > 0f ? value : 0f; }
    }


    public Timer(float time)
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
