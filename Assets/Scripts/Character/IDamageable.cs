public delegate void OnDamageDeleagate(float damage);

public interface IDamageable
{
    public event OnDamageDeleagate OnDamage;


    public void TakeDamage(float damage);
}