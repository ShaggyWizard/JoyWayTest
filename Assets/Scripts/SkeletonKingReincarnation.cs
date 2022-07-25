using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonKingReincarnation : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Transform _bonesContainer;


    private List<ReincarnationBone> _bones = new List<ReincarnationBone>();
    private IDeath _death;
    private IRespawn _respawn;
    private Timer _timer;


    private void Awake()
    {
        if (!TryGetComponent(out _death) || !TryGetComponent(out _respawn)) { Destroy(this); }
        foreach (Transform child in _bonesContainer)
        {
            _bones.Add(child.gameObject.AddComponent<ReincarnationBone>());
        }
        _death.OnDeath += Break;
        _respawn.OnRespawn += StartReincarnation;

        _timer = new Timer();
        _timer.OnTimerEnd += FinishReincarnation;
    }
    private void OnDestroy()
    {
        _death.OnDeath -= Break;
        _respawn.OnRespawn -= StartReincarnation;
    }
    private void Update()
    {
        if (_timer.TryUpdate(Time.deltaTime))
        {
            ReincarnationLerp(_timer.Progress * _timer.Progress);
        }
    }

    private void ReincarnationLerp(float time)
    {
        foreach (var bone in _bones) { bone?.Lerp(time); }
    }
    private void Break()
    {
        foreach (var bone in _bones) { bone?.Break(); }
    }
    private void StartReincarnation()
    {
        if (!_timer.Finished) { return; }
        _timer.Set(_duration);
        foreach (var bone in _bones) { bone?.StartReincarnation(); }
    }
    private void FinishReincarnation()
    {
        foreach (var bone in _bones) { bone?.FinishReincarnation(); }
    }
}
