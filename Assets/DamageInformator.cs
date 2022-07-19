using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInformator : MonoBehaviour
{
    [SerializeField] private DamageInfo _damageInfoPrefab;
    [SerializeField] private Transform _start;
    [SerializeField] private float _duration;
    [SerializeField] private float _speed;
    [SerializeField] private Color _color;


    private IDamageable _damageable;


    private void Awake()
    {
        if (!TryGetComponent(out _damageable)) { Destroy(this); }

        _damageable.OnDamage += SpawnInfo;
    }


    private void SpawnInfo(float damage)
    {
        DamageInfo text = Instantiate(_damageInfoPrefab);
        text.Init(damage, _duration, _start, _speed, _color);
    }
}
