using TMPro;
using UnityEngine;
using Novella.Dialog;

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
