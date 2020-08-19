using System.Collections.Generic;
using UnityEngine;

namespace Novella.Dialog.Act
{
    public class Actor : MonoBehaviour
    {
        public DialogCharacter character;
        public ActorState currentState;
        public List<Transition> transitions;

        private StageForActors _stage;

        public int TransitionCount => transitions.Count;

        public void ApplyTransition(int index)
        {
            if (index >= TransitionCount) return;

            // the first transition is actor's starting state
            if (index == 0)
            {
                currentState = transitions[0].actorState;
                return;
            }


        }

        private void Move(Vector2 relativePosition, TransitionMoveType moveType = TransitionMoveType.None)
        {
            if (_stage == null) _stage = transform.parent.GetComponent<StageForActors>();

            Vector2 destination = new Vector2(_stage.Width * relativePosition.x, _stage.Height * relativePosition.y) / 2;

            switch (moveType)
            {
                case TransitionMoveType.None:
                    break;
                case TransitionMoveType.Teleport:
                    //currentState.relativePosition
                    break;
                case TransitionMoveType.Linear:
                    break;
                case TransitionMoveType.Smooth:
                    break;
            }
        }

        private void Flip()
        {

        }

        private void Darken()
        {

        }

        private void ChangeOpacity()
        {

        }
        
    }
}