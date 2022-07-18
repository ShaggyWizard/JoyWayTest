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
    private float _timer = 0;


    private void Awake()
    {
        if (!TryGetComponent(out _death) || !TryGetComponent(out _respawn)) { Destroy(this); }
        foreach (Transform child in _bonesContainer)
        {
            _bones.Add(child.gameObject.AddComponent<ReincarnationBone>());
        }
        _death.OnDeath += Break;
        _respawn.OnRespawn += Reincarnate;
    }
    private void OnDestroy()
    {
        _death.OnDeath -= Break;
        _respawn.OnRespawn -= Reincarnate;
    }
    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            float progress = 1f - (_timer / _duration);
            ReincarnationLerp(progress* progress);
        }
    }

    private void Reincarnate()
    {
        {
            _timer = _duration;
            foreach (var bone in _bones) { bone?.Reincarnate(); }
        }
    }
    private void Break()
    {
        foreach (var bone in _bones) { bone?.Break(); }
    }
    private void ReincarnationLerp(float time)
    {
        foreach (var bone in _bones) { bone?.Lerp(time); }
    }
}
