using System.Collections.Generic;
using UnityEngine;


public class ParticleCollisionEffector : MonoBehaviour
{
    [SerializeField] private AbstractEffect[] _effects;


    private ParticleSystem _particleSystem;
    private event EffectTargetDelegate OnEffect;


    private List<ParticleCollisionEvent> _collisionEvents = new List<ParticleCollisionEvent>();


    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        OnEffect += TryEffect;
    }
    private void OnParticleCollision(GameObject other)
    {
        int eventsCount = _particleSystem.GetCollisionEvents(other, _collisionEvents);

        var otherTransform = other.transform;

        for (int i = 0; i < eventsCount; i++)
        {
            OnEffect?.Invoke(otherTransform);
        }
    }


    private void TryEffect(Transform target)
    {
        if (!target.TryGetComponent(out IEffectable effectable)) { return; }

        foreach (var effect in _effects)
        {
            effectable.AddEffect(Instantiate(effect));
        }
    }
}
