﻿using System;
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
        public string expression;
        public bool isDarkened;
        public Vector2 position;
        public TransitionType transitionType;
        //public effect like jump or duck or other tween
    }
}
