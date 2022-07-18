using System;


public  interface IUsable
{
    public event Action OnUse;

    public void Use();
}