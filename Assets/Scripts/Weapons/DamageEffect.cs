using UnityEngine;


public class DamageEffect : MonoBehaviour, IEffector
{
    [SerializeField] float _damage;

    public void Effect(RaycastHit hitInfo)
    {
        if (hitInfo.transform.TryGetComponent(out IHealth target))
        {
            target.ModifyHealth(-_damage);
        }
    }
}
