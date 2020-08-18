using Novella.Dialog;
using Novella.Dialog.Act;
using UnityEngine;

public class monikatest : MonoBehaviour
{

    //public StageForActors stage;
    public DialogCharacter dialogCharacter;

    private GameObject _actorObjet;
    private Actor _actor;

    private void Awake()
    {
        _actorObjet = Instantiate(new GameObject());
        _actor = _actorObjet.AddComponent<Actor>();
    }

    private void Start()
    {
        _actor.Instialize(dialogCharacter);
        DialogCharacterState transition = new DialogCharacterState(dialogCharacter, new Vector2(0.5f, -0.5f), TransitionType.None);
        _actor.ApplyTransition(transition);
    }


}
