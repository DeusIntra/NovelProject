using TMPro;
using UnityEngine;

namespace Novella.Dialog
{
    public class TextEffectHolder : MonoBehaviour
    {
        private ITextEffect[] _textEffects = null;

        private void Awake()
        {
            _textEffects = GetComponents<ITextEffect>();
        }

        public void ApplyAll(TMP_Text text)
        {
            foreach (var effect in _textEffects)
            {
                effect.Apply(text);
            }
        }

        public void TerminateAll()
        {
            foreach (var effect in _textEffects)
            {
                effect.Terminate();
            }
        }
    }
}
