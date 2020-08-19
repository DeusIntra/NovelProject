using UnityEngine;

namespace Novella.Dialog.Act
{
    public enum TransitionMoveType { None, Teleport, Linear, Smooth }
    // this is for later
    //public enum TransitionEffect { FadeIn, FadeOut }

    public class Transition : MonoBehaviour
    {
        public bool useTransition;
        public ActorState actorState;
        public TransitionMoveType type;
        // public List<TransitionEffect> transitionEffects;
    }
}
