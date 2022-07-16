using System;
using UnityEngine;


public interface IGrabable
{
    public event Action OnPickUpEvent;
    public event Action OnDropEvent;


    public void OnPickUp();
    public void OnDrop();
    public void SetPosition(Transform slot);
}