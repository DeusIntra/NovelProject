using System;
using UnityEngine;

namespace Novella.Dialog.Act
{
    public enum TransitionType 
    { 
        None, Linear, Smooth, 
        AppearFromLeft, LeaveToLeft, 
        AppearFromRight, LeaveToRight, 
        FadeIn, FadeOut, 
        AppearFromBottom, LeaveToBottom, 
        AppearFromTop, LeaveToTop 
    }

    [Serializable]
    public class DialogCharacterState
    {
        public DialogCharacter Character;
        public Vector2 relativePosition;
        public TransitionType transitionType;
        //public string expression;
        public bool flipHorizontally;
        public bool flipVertically;
        public bool isDarkened; // should make it into float 
        //public effect like jump or duck or other tween

        public DialogCharacterState
            (DialogCharacter character, 
            Vector2 relativePosition, 
            TransitionType transitionType, 
            bool flipHorizontally = false, bool flipVertically = false, bool isDarkened = false)
        {
            Character = character;
            this.relativePosition = relativePosition;
            this.transitionType = transitionType;
            this.flipHorizontally = flipHorizontally;
            this.flipVertically = flipVertically;
            this.isDarkened = isDarkened;
        }
    }
}
