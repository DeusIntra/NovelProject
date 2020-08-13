﻿using TMPro;

/// <summary>
/// Text animations apply when text appears
/// </summary>
public interface ITextAnimation
{
    bool isAnimating();
    void Animate(TMP_Text text, float speed);
    void StopAnimation();
}
