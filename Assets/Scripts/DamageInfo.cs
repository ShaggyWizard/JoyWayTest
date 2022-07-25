using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInfo : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshPro _text;


    private Timer _timer;
    private float _speed;
    private Color _color;
    private Color _colorTransparent;

    private const float _alphaPow = 4;

    public void Init(float damage, float duration, Transform start, float speed, Color color)
    {
        transform.position = start.position;
        _speed = speed;

        _color = color;
        _colorTransparent = new Color(color.r, color.g, color.b, 0);

        _timer = new Timer(duration);
        _timer.OnTimerEnd += DestroyMe;

        _text.text = $"-{damage}";
        _text.color = color;
    }


    private void Update()
    {
        _timer.TryUpdate(Time.deltaTime);
        transform.position += Vector3.up * _speed * Time.deltaTime;
        float alpha = Mathf.Pow(_timer.Progress, _alphaPow);
        _text.color = Color.Lerp(_color, _colorTransparent, alpha);
    }


    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
