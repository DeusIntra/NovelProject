using TMPro;
using UnityEngine;

public class TextNoAnimation : MonoBehaviour, ITextAnimation
{
    public bool isAnimating()
    {
        return false;
    }

    public void Animate(TMP_Text text, float speed)
    {
        return;
    }

    public void StopAnimation()
    {
        return;
    }
}
