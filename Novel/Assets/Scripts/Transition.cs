using System;

namespace Novella.Dialog.Act
{
    public enum TransitionMoveType { None, Instant, Linear, Smooth }
    // this is for later
    //public enum TransitionEffect { FadeIn, FadeOut }

    [Serializable]
    public class Transition
    {
        public bool useTransition;
        public ActorState actorState;
        public TransitionMoveType type;
        public float timeInSeconds = 0.5f;
        // public List<TransitionEffect> transitionEffects;
    }
}
