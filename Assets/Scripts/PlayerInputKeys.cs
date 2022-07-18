using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputKeys : MonoBehaviour
{
    [SerializeField] private List<KeyUnityEvent> _keyActions;

    private void Update()
    {
        foreach (var keyAction in _keyActions)
        {
            if (Input.GetKeyDown(keyAction.Key))
            {
                keyAction.Action?.Invoke();
            }
        }
    }
}
