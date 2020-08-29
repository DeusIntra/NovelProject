using System;
using UnityEngine;

namespace Novella.Dialog.Act
{
    public enum TransitionMoveType { None, Instant, Linear, Smooth }
    // this is for later
    //public enum TransitionEffect { FadeIn, FadeOut }

    [Serializable]
    public class Transition
    {
        [Header("Actor State")]
        [SerializeField] private Vector2 _relativePosition;
        [SerializeField] private bool _flip = false;
        [SerializeField] private float scale = 1f;
        [SerializeField] [Range(0, 1)] private float _darkness = 0f;
        [SerializeField] [Range(0, 1)] private float _opacity = 1f;

        [Space]
        public TransitionMoveType type;
        public float timeInSeconds = 0.5f;
        // public List<TransitionEffect> transitionEffects;

        public ActorState actorState => new ActorState(_relativePosition, _flip, scale, _darkness, _opacity);        
        
    }
}
