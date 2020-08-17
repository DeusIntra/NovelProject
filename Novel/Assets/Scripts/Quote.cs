using System;
using TMPro;
using UnityEngine;

namespace Novella.Dialog
{
    [Serializable]
    public class Quote // should add "auto finish" and "hide dialog" fields
    {
        [SerializeField] private string _characterName = null;
        [SerializeField] [TextArea] private string _text = null;
        [SerializeField] private Sprite _faceIcon = null;
        [SerializeField] private DialogCharacter _character = null;
        [SerializeField] private TMP_FontAsset _font = null;
        [SerializeField] private int _fontSize = 0;

        public string CharacterName
        {
            get
            {
                if (_character != null && (_characterName == ""))
                    return _character.name;

                return _characterName;
            }
        }
        public string Text => _text;
        public Sprite FaceIcon
        {
            get
            {
                if (_character != null && _faceIcon == null)
                    return _character.FaceIcon;
                return _faceIcon;
            }
        }
        public TMP_FontAsset Font
        {
            get
            {
                if (_character != null && _font == null)
                    return _character.Font;
                return _font;
            }
        }
        public Color? TextColor
        {
            get
            {
                if (_character != null && _character.UseTextColor)
                    return _character.TextColor;
                return null;
            }
        }
        public int FontSize
        {
            get
            {
                if (_character != null && _character.FontSize != 0)
                    return _character.FontSize;
                return _fontSize;
            }
        }
    }
}
