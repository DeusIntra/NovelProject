using Novel.Events;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Novel.Dialog
{

    [Serializable]
    public class Quote
    {
        [SerializeField] private string _characterName = null;
        [SerializeField] [TextArea] private string _text = null;
        [SerializeField] private Sprite _faceIcon = null;
        [SerializeField] private DialogCharacter _character = null;
        [SerializeField] private TMP_FontAsset _font = null;
        [ColorUsage(false)][SerializeField] private Color _fontColor = Color.black;

        public string CharacterName
        {
            get
            {
                if (_character != null && (_characterName == ""))
                    return _character.name;

                return _characterName;
            }
        }
        public string Text { get => _text; }
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
        public Color FontColor
        {
            get
            {
                if (_character != null && _character.FontColor != null)
                    return _character.FontColor;
                return Color.black;
            }
        }
    }
}
