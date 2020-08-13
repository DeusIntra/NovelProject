#pragma warning disable 0649

using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Scriptable Object/RPG/Effect", order = 52)]
public abstract class Effect : ScriptableObject
{
    [SerializeField] private string _effectName;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;

    public string EffectName => _effectName;
    public string Description => _description;
    public Sprite Sprite => _sprite;

    public abstract void Apply();
}
