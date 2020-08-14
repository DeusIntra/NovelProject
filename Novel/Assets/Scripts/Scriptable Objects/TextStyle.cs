#pragma warning disable 0649

using TMPro;
using UnityEngine;

namespace Novella.Dialog
{
    [CreateAssetMenu(fileName = "New Text Style", menuName = "Scriptable Object/Dialog/Text Style", order = 53)]
    public class TextStyle : ScriptableObject
    {
        [SerializeField] private Color _textColor;
        [SerializeField] private TMP_FontAsset _font;
        [SerializeField] private int _fontSize;

        public Color TextColor => _textColor;
        public TMP_FontAsset Font => _font;
        public int FontSize => _fontSize;
    }
}
