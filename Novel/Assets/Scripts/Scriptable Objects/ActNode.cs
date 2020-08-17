using System.Collections.Generic;
using UnityEngine;

namespace Novella.Dialog.Act
{
    [CreateAssetMenu(fileName = "New Act", menuName = "Scriptable Object/Dialog/Act", order = 52)]
    public class ActNode : ScriptableObject
    {
        public List<GameObject> characterGameObjects;
        public List<DialogCharacterState> characterStates;
        public List<ActTransition> transitions;

        private int currentTransitionIndex;

        private ActTransition CurrentTransition => transitions[currentTransitionIndex];


        public void ApplyTransition(GameObject parentPanel)
        {
            if (currentTransitionIndex >= transitions.Count) return;

            // find characters in transitions that are not in states
            // and add them to states
            foreach (DialogCharacterState characterState1 in CurrentTransition.CharacterStates)
            {
                foreach (DialogCharacterState characterState2 in characterStates)
                {
                    if (characterState1.Character == characterState2.Character)
                        continue;
                    else
                        characterStates.Add(characterState1);
                }
            }

            foreach (DialogCharacterState characterState in characterStates)
            {
                // find character GameObject in the scene or create if there is none
                
                
                // apply animation and/or effect

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
