#pragma warning disable 0649

using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Scriptable Object/RPG/Character", order = 52)]
public class Character : ScriptableObject
{
    [SerializeField] private string _characterName;
    [SerializeField] private Sprite _faceIcon;
    [SerializeField] private float _age;
    [SerializeField] private string _sex;

    public string CharacterName => _characterName;
    public Sprite FaceIcon => _faceIcon;
    public float Age => _age;
    public string Sex => _sex;
}
