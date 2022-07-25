using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputKeys : MonoBehaviour
{
    [SerializeField] private List<KeyUnityEvent> _keyDown;
    [SerializeField] private List<KeyUnityEvent> _keyUp;

    private void Update()
    {
        foreach (var keyAction in _keyDown)
        {
            if (Input.GetKeyDown(keyAction.Key))
            {
                keyAction.Action?.Invoke();
            }
        }
        foreach (var keyAction in _keyUp)
        {
            if (Input.GetKeyUp(keyAction.Key))
            {
                keyAction.Action?.Invoke();
            }
        }
    }
}
