using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectIdAttribute : PropertyAttribute { }

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ScriptableObjectIdAttribute))]
public class ScriptableObjectIdDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        AssetDatabase.TryGetGUIDAndLocalFileIdentifier(property.serializedObject.targetObject, out string guid, out long localId);
        if (property.stringValue != guid)
        {
            property.stringValue = guid;
        }
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
#endif

[Serializable]
public abstract class AbstractEffect : ScriptableObject, IBuff
{
    [ScriptableObjectId]
    public string guid;


    [Header("Base options")]
    [SerializeField] private AbstractEffect[] _restricted;

    public abstract void Init(IEffectable target);
    public virtual bool Compatible(EffectsHandler target)
    {
        //Check if buffs contains restricted buff
        foreach (var restrictedEffect in _restricted)
        {
            if (target.Effects.Where(effect => effect.guid == restrictedEffect.guid).Any()) { return false; }
        }

        return true;
    }
}