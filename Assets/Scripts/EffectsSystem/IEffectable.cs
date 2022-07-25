using System.Collections.Generic;

public interface IEffectable
{
    public List<AbstractEffect> Effects { get; }


    public void AddEffect(AbstractEffect effect);
    public void RemoveEffect(AbstractEffect effect);
}