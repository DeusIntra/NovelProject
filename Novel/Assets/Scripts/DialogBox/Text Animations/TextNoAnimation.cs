using TMPro;
using UnityEngine;
using Novella.Dialog;

// has a bug: if no animation is selected, text effects don't apply on first quote.
// fixing it is not a priority
public class TextNoAnimation : MonoBehaviour, ITextAnimation
{
    public bool isAnimating()
    {
        return false;
    }

    public void Animate(TMP_Text text)
    {
        return;
    }

    public void StopAnimation()
    {
        return;
    }
}
