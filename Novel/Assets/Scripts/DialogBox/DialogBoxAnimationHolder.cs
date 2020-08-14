using UnityEngine;

namespace Novella.Dialog
{
    public class DialogBoxAnimationHolder : MonoBehaviour
    {
        public int animationIndex = 0;

        private IDialogBoxAnimation[] _dialogAnimations = null;

        public IDialogBoxAnimation CurrentAnimation
        {
            get
            {
                if (animationIndex < _dialogAnimations.Length)
                    return _dialogAnimations[animationIndex];
                return null;
            }
        }

        private void Awake()
        {
            _dialogAnimations = GetComponents<IDialogBoxAnimation>();
        }
    }
}
