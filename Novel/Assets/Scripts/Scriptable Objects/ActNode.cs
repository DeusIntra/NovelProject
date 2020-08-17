using System.Collections.Generic;
using UnityEngine;

namespace Novella.Dialog.Act
{
    [CreateAssetMenu(fileName = "New Act", menuName = "Scriptable Object/Dialog/Act", order = 52)]
    public class ActNode : ScriptableObject
    {
        public List<Actor> actors;
        public List<DialogCharacterState> characterStates;
        public List<ActTransition> transitions;

        private int currentTransitionIndex;

        private ActTransition CurrentTransition => transitions[currentTransitionIndex];

        public void ApplyTransition()
        {
            if (currentTransitionIndex >= transitions.Count) return;

            foreach (DialogCharacterState transitionState in CurrentTransition.CharacterStates)
            {
                // find character GameObject in the scene or create if there is none

                Actor actor = null;
                foreach (Actor loopActor in actors) // find actor on the scene
                {
                    if (loopActor.Character == transitionState.Character)
                    {
                        actor = loopActor;
                        break;
                    }
                }

                if (actor == null) // create actor if there is none
                {
                    GameObject actorObjet = Instantiate(new GameObject());
                    actor = actorObjet.AddComponent<Actor>();
                    actor.Instialize(transitionState.Character);
                }

                actor.ApplyTransition(transitionState);


                /*
                foreach (DialogCharacterState characterState in characterStates)
                {
                    if (transitionState.Character == characterState.Character)
                        continue;
                    else
                        characterStates.Add(transitionState);                    
                }

                foreach (DialogCharacterState characterState in characterStates)
                {
                    // find character GameObject in the scene or create if there is none
                    bool isPresent = false;
                    Actor actor;
                    foreach (Actor loopActor in actors)
                    {
                        if (loopActor.Character == characterState.Character)
                        {
                            actor = loopActor;
                            isPresent = true;
                            break;
                        }
                    }

                    if (!isPresent) // create actor
                    {
                        GameObject actorObjet = Instantiate(new GameObject(), parentPanel);
                        actor = actorObjet.AddComponent<Actor>();
                        actor.Instialize(characterState.Character);
                    }

                    // apply animation and/or effect
                    // actor.Move()
                }*/
            }

            currentTransitionIndex++;
        }

        public void StopTransition()
        {

        }
        /*
        List<ActState> states;
        int currentStateIndex;
        public ActState currentState => states[currentStateIndex];
        public ActState previousState => states[currentStateIndex - 1];

        private void OnEnable()
        {
            currentStateIndex = 0;
        }

        // probably shitcode but whatever
        public ActState NextState()
        {
            if (++currentStateIndex >= states.Count)
            {
                currentStateIndex = 0;
                return null;
            }
            return currentState;
        }*/
    }
}
