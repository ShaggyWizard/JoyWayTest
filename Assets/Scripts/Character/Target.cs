using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable, IEffectable, IMultiplyColor
{
    [SerializeField] private MeshRenderer[] _meshes;

    public event OnDamageDeleagate OnDamage;
    public EffectsHandler _effects;


    public List<AbstractEffect> Effects => _effects.Effects;


    public void AddEffect(AbstractEffect effect) { _effects.AddEffect(effect); }
    public void RemoveEffect(AbstractEffect effect) { _effects.RemoveEffect(effect); }
    public void TakeDamage(float damage)
    {
        OnDamage?.Invoke(damage);
    }


    private void Awake()
    {
        _effects = new EffectsHandler(this);
    }
    private void Update()
    {
        _effects.Update(Time.deltaTime);
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
