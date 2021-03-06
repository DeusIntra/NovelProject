﻿using UnityEngine;
using UnityEngine.Events;

namespace Novella
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent gameEvent = null;
        [SerializeField] private UnityEvent response = null;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            response.Invoke();
        }
    }
}
