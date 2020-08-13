using TMPro;

public interface ITextAnimation
{
    bool isAnimating();
    void Animate(TMP_Text text, float speed);
    void StopAnimation();
}
