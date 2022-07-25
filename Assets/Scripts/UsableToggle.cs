using System;
using UnityEngine;

public class UsableToggle : MonoBehaviour, IUsable, IDisusable
{
    public event Action OnUse;
    public event Action OnDisuse;


    public void Use() { OnUse?.Invoke(); }
    public void Disuse() { OnDisuse?.Invoke(); }
}
