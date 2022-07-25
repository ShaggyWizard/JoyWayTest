using System;

public interface IHealth
{
    public float Health { get; }


    public event Action OnModifyHealth;
}