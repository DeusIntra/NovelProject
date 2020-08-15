using System.Collections.Generic;
using UnityEngine;

namespace Novella.Dialog
{
    [CreateAssetMenu(fileName = "New Act", menuName = "Scriptable Object/Dialog/Act", order = 52)]
    public class ActNode : ScriptableObject
    {
        public List<DialogCharacterState> states;
        public List<ActTransition> transitions;


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
