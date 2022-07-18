using System;


public interface IDeath
{
    public event Action OnDeath;


    public void Die();
}
