using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class KeyUnityEvent
{
    public KeyCode Key;
    public UnityEvent Action;
}