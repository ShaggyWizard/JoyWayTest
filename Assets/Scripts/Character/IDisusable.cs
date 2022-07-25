using System;


public  interface IDisusable
{
    public event Action OnDisuse;


    public void Disuse();
}