using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private TextContainer _display;


    [SerializeField] private IHealth _health;


    private void OnEnable()
    {
        _health = _target.GetComponent<IHealth>();
        if (_health == null) { return; }
        _health.OnModifyHealth += UpdateDisplay;
    }
    private void OnDisable()
    {
        if (_health == null) { return; }
        _health.OnModifyHealth -= UpdateDisplay;
    }

    private void UpdateDisplay()
    {
        _display.SetText($"{_health.Health}");
    }
}
