public delegate void OnDamageDeleagate(float damage);

internal interface IDamageable
{
    public event OnDamageDeleagate OnDamage;


    public void TakeDamage(float damage);
}