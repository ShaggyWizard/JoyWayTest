using UnityEngine;


public class DamageOverTimeEffect : MonoBehaviour, IEffector
{
    [SerializeField] string _name;
    [SerializeField] float _damage;
    [SerializeField] float _duration;
    [SerializeField] float _tickRate;
    [SerializeField] bool _canStack;
    [SerializeField] bool _resetTimer;


    public void Effect(RaycastHit hitInfo)
    {
        DamageOverTimeStatusBehavior dot = hitInfo.transform.gameObject.GetComponent<DamageOverTimeStatusBehavior>();
        if (dot == null)
        {
            dot = hitInfo.transform.gameObject.AddComponent<DamageOverTimeStatusBehavior>();
        }
        dot.Init(_name, _duration, _tickRate, _damage, _canStack, _resetTimer);
    }
}
