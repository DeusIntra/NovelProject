using UnityEngine;

namespace Novella.Dialog
{
    public class TextRevealHolder : MonoBehaviour
    {
        [HideInInspector] public int animationIndex = 0;

        private ITextAnimation[] _textAnimations = null;

        public ITextAnimation CurrentAnimation
        {
            get
            {
                if (animationIndex < _textAnimations.Length)
                    return _textAnimations[animationIndex];
                return null;
            }
        }

        public string[] AnimationNames // used for custom editor
        {
            get
            {
                ITextAnimation[] animations = GetComponents<ITextAnimation>();
                string[] animationNames = new string[animations.Length];
                for (int i = 0; i < animations.Length; i++)
                {
                    animationNames[i] = animations[i].GetType().Name;
                }
                return animationNames;
            }
        }

        private void Awake()
        {
            _textAnimations = GetComponents<ITextAnimation>();
        }

    }
}
