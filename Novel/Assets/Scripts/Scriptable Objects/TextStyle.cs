#pragma warning disable 0649

using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New Text Style", menuName = "Scriptable Object/Dialog/Text Style", order = 53)]
public class TextStyle : ScriptableObject
{
    [SerializeField] private Color _textColor;
    [SerializeField] private TMP_FontAsset _font;
    [SerializeField] private int _fontSize;

    public Color TextColor { get => _textColor; }
    public TMP_FontAsset Font { get => _font; }
    public int FontSize { get => _fontSize; }
}
