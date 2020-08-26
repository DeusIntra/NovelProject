using System;
using UnityEngine;

namespace Novella.Dialog.Act
{
    [Serializable]
    public struct ActorState
    {
        [HideInInspector] public Vector2 position;
        public Vector2 relativePosition;
        public bool flip;
        public float scale;
        [Range(0, 1)] public float darkness;
        [Range(0, 1)] public float opacity;
    }
}
