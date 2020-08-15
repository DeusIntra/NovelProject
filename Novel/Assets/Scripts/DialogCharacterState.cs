using UnityEngine;

namespace Novella.Dialog
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

    public class DialogCharacterState
    {
        public DialogCharacter character;
        public string expression;
        public bool isDarkened;
        public Vector2 position;
        public TransitionType transitionType;
    }
}
