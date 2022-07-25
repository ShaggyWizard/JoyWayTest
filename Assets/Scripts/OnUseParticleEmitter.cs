using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnUseParticleEmitter : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> particleSystems;


    private IUsable _usable;
    private IDisusable _disusable;


    private void Awake()
    {
        _usable = GetComponent<IUsable>();
        _disusable = GetComponent<IDisusable>();
    }
    private void OnEnable()
    {
        if (_usable != null) { _usable.OnUse += PlayParticles; }
        if (_disusable != null) { _disusable.OnDisuse += StopParticles; }
    }
    private void OnDisable()
    {
        if (_usable != null) { _usable.OnUse -= PlayParticles; }
        if (_disusable != null) { _disusable.OnDisuse += StopParticles; }
    }

    private void PlayParticles()
    {
        foreach (var particle in particleSystems)
        {
            particle?.Play();
        }
    }
    private void StopParticles()
    {
        foreach (var particle in particleSystems)
        {
            particle?.Stop();
        }
    }
}
