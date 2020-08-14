#pragma warning disable 0649

using UnityEngine;

namespace Novella.RPG
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "Scriptable Object/RPG/Spell", order = 52)]
    public abstract class Spell : ScriptableObject
    {
        [SerializeField] private string _spellName;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;

        public string Spellname => _spellName;
        public string Description => _description;
        public Sprite Icon => _icon;

        public abstract void Cast();
    }
}
