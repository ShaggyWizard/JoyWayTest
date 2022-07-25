using UnityEngine;


[CreateAssetMenu(menuName = "Effect/Multiply Color")]
public class EffectMultiplyColor : AbstractEffect, IContinious
{
    [Header("Multiply Color options")]
    [SerializeField] private ScriptableColor _color;


    private IMultiplyColor _target;

    

    public override void Init(IEffectable target)
    {
        if (target is IMultiplyColor)
        {
            _target = (IMultiplyColor)target;
            _target.MultiplyColor(_color.color); 
        }
    }

    public void OnEnd()
    {
        _target?.DivideColor(_color.color);
    }
}