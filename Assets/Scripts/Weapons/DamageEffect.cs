using UnityEngine;


public class DamageEffect : MonoBehaviour, IEffector
{
    [SerializeField] float _damage;

    public void Effect(RaycastHit hitInfo)
    {
        if (hitInfo.transform.TryGetComponent(out IDamageable target))
        {
            target.TakeDamage(_damage);
        }
    }
}
