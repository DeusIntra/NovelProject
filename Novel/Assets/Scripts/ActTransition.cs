using System;
using System.Collections.Generic;
using UnityEngine;


namespace Novella.Dialog
{
    [Serializable]
    public class ActTransition
    {
        [SerializeField] private List<DialogCharacterState> _characterStates;

        public List<DialogCharacterState> CharacterStates => _characterStates;
    }
}
