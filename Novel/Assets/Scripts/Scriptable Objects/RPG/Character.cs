#pragma warning disable 0649

using UnityEngine;

namespace Novel.RPG
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Scriptable Object/RPG/Character", order = 52)]
    public class Character : ScriptableObject
    {
        [SerializeField] private string _characterName;
        [SerializeField] private Sprite _faceIcon;
        [SerializeField] private float _age;
        [SerializeField] private string _sex;

        public string CharacterName { get => _characterName; }
        public Sprite FaceIcon { get => _faceIcon; }
        public float Age { get => _age; }
        public string Sex { get => _sex; }
    }
}
