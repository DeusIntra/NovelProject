#pragma warning disable 0649

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Novella.Dialog.Act
{
    [Serializable]
    public class ActorToCreate
    {
        [SerializeField] private DialogCharacter _character;
        [SerializeField] private ActorState _initialState;
        [SerializeField] private List<Transition> _transitions;

        public DialogCharacter Character => _character; 
        public ActorState InitialState => _initialState;
        public List<Transition> Transitions => _transitions;
    }
}
