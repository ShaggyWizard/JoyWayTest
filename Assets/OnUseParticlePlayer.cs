using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnUseParticlePlayer : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> particleSystems;


    private IUsable _usable;


    private void Awake()
    {
        _usable = GetComponent<IUsable>();
    }
    private void OnEnable()
    {
        if (_usable != null) { _usable.OnUse += PlayParticles; }
    }
    private void OnDisable()
    {
        if (_usable != null) { _usable.OnUse -= PlayParticles; }
    }

    private void PlayParticles()
    {
        foreach (var particle in particleSystems)
        {
            particle?.Play();
        }
    }
}
