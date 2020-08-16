using UnityEngine;

namespace Novella.Dialog
{
    public interface IDialogBoxAnimation
    {
        bool isAnimating();
        void Open(GameObject gameObject);
        void Close(GameObject gameObject);
    }
}
