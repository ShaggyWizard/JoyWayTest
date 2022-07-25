using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour, IHealth, IRespawn, IDeath, IDamageable, IEffectable, IMultiplyColor
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private MeshRenderer[] _meshes;
    [SerializeField] private TextContainer _effectsDebug;


    public EffectsHandler _effects;
    public event Action OnRespawn;
    public event Action OnDeath;
    public event Action OnModifyHealth;
    public event OnDamageDeleagate OnDamage;

    private Collider[] _colliders;


    public float Health
    {
        get { return _health; }
        private set
        {
            _health = value > 0f ? value : 0f;
            OnModifyHealth?.Invoke();
            if (Health == 0) { Die(); }
        }
    }
    public List<AbstractEffect> Effects => _effects.Effects;


    public void TakeDamage(float damage)
    {
        Health -= damage;
        OnDamage?.Invoke(damage);
    }
    public void AddEffect(AbstractEffect effect) { _effects.AddEffect(effect); }
    public void RemoveEffect(AbstractEffect effect) { _effects.RemoveEffect(effect); }
    public void Die()
    {
        foreach (var collider in _colliders) { collider.enabled = false; }
        OnDeath?.Invoke();
    }
    public void Respawn()
    {
        foreach (var collider in _colliders) { collider.enabled = true; }
        Health = _maxHealth;
        OnRespawn?.Invoke();
    }

    private void Awake()
    {
        Health = Health < 0 ? _maxHealth : Health;
        _colliders = GetComponents<Collider>();
        _effects = new EffectsHandler(this);
    }
    private void Update()
    {
        _effects.Update(Time.deltaTime);
        if (_effectsDebug != null)
        {
            string debug = "";
            foreach (var effect in Effects)
            {
                debug += $"{effect.name}\n";
            }
            _effectsDebug.SetText(debug);
        }
    }

    public void MultiplyColor(Color color)
    {
        foreach (var mesh in _meshes)
        {
            foreach (var material in mesh.materials)
            {
                material.color *= color;
            }
        }
    }
    public void DivideColor(Color color)
    {
        foreach (var mesh in _meshes)
        {
            foreach (var material in mesh.materials)
            {
                Color meshColor = material.color;
                material.color = new Color(meshColor.r / color.r, meshColor.g / color.g, meshColor.b / color.b, meshColor.a / color.a);
            }
        }
    }
}
