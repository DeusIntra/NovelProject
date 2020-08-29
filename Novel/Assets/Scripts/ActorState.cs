using System;
using UnityEngine;

namespace Novella.Dialog.Act
{
    [Serializable]
    public struct ActorState
    {
        public Vector2 position;
        public Vector2 relativePosition;
        public bool flip;
        public float scale;
        public float darkness;
        public float opacity;

        public ActorState(Vector2 relativePosition, bool flip = false, float scale = 1f, float darkness = 0f, float opacity = 1f)
        {
            this.position = Vector2.zero;
            this.relativePosition = relativePosition;
            this.flip = flip;
            this.scale = scale;
            this.darkness = darkness;
            this.opacity = opacity;
        }

        public ActorState(Vector2 position, Vector2 relativePosition, bool flip = false, float scale = 1f, float darkness = 0f, float opacity = 1f)
        {
            this.position = position;
            this.relativePosition = relativePosition;
            this.flip = flip;
            this.scale = scale;
            this.darkness = darkness;
            this.opacity = opacity;
        }
    }
}
