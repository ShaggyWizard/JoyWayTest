using UnityEngine;

public class TextContainer : MonoBehaviour
{
    private TMPro.TextMeshPro _text;


    public void SetText(string text)
    {
        if (_text == null) { return; }

        _text.text = text;
    }


    private void Awake()
    {
        _text = GetComponent<TMPro.TextMeshPro>();
    }
}
