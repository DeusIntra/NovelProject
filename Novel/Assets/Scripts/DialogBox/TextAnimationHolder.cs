using UnityEngine;

public class TextAnimationHolder : MonoBehaviour
{
    public int animationIndex = 0;

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

    private void Awake()
    {
        _textAnimations = GetComponents<ITextAnimation>();
    }
}
