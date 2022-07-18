using System;


public interface IRespawn
{
    public event Action OnRespawn;


    public void Respawn();
}
