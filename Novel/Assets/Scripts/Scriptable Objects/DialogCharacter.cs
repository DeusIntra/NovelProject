using TMPro;
using UnityEngine;

namespace Novella.Dialog
{
    [CreateAssetMenu(fileName = "New Dialog Character", menuName = "Scriptable Object/Dialog/Character", order = 52)]
    public class DialogCharacter : ScriptableObject
    {
        [SerializeField] private string _name = null;
        [SerializeField] private Sprite _faceIcon = null;
        // [SerializeField] private Dictionary<string, Sprite> _expressions = null;
        [SerializeField] private Sprite _bodyImage = null;
        [SerializeField] private Vector2 _bodyImageScale = new Vector2();
        [SerializeField] private TMP_FontAsset _font = null;
        [SerializeField] private int _fontSize = 0;
        [SerializeField] private bool _useFontColor = false;
        [SerializeField] private Color _fontColor = new Color();
        // sprite scale

        public string Name => _name;
        public Sprite FaceIcon => _faceIcon;
        // public Dictionary<string, Sprite> Expressions => _expressions;
        public Sprite BodyImage => _bodyImage;
        public Vector2 BodyImageScale => _bodyImageScale;
        public TMP_FontAsset Font => _font;
        public int FontSize => _fontSize;
        public bool UseTextColor => _useFontColor;
        public Color TextColor => _fontColor;


        private void OnEnable()
        {
            _fontColor.a = 255;
        }

    }
}
