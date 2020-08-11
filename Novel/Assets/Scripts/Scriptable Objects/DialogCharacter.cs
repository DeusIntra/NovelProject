using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog Character", menuName = "Scriptable Object/Dialog/Character", order = 52)]
public class DialogCharacter : ScriptableObject
{
    [SerializeField] private string _name = null;
    [SerializeField] private Sprite _faceIcon = null;
    [SerializeField] private Dictionary<string, Sprite> _expressions = null;
    [SerializeField] private TMP_FontAsset _font = null;
    [SerializeField] private int _fontSize = 0;
    [SerializeField] private bool _useFontColor = false;
    [SerializeField] private Color _fontColor = new Color();

    public string Name { get => _name; }
    public Sprite FaceIcon { get => _faceIcon; }
    public Dictionary<string, Sprite> Expressions { get => _expressions; }
    public TMP_FontAsset Font { get => _font; }
    public int FontSize { get => _fontSize; }
    public bool UseTextColor { get => _useFontColor; }
    public Color TextColor { get => _fontColor; }
}
