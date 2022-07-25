public interface IUpdateable : IContinious
{
    public bool TryUpdate(float deltaTime);
}