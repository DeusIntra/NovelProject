using System.Collections;
using TMPro;
using UnityEngine;
using Novella.Dialog;

public class TextCharReveal : MonoBehaviour, ITextAnimation
{
    public float charsPerSecond = 15f;

    private bool _isAnimating;
    private TMP_Text _textComponent;
    private Coroutine _coroutine;

    public bool isAnimating()
    {
        return _isAnimating;
    }

    public void Animate(TMP_Text text)
    {
        _textComponent = text;
        _coroutine = StartCoroutine(AnimationCoroutine());
    }

    public void StopAnimation()
    {
        _isAnimating = false;
        StopCoroutine(_coroutine);
        _textComponent.maxVisibleCharacters = _textComponent.textInfo.characterCount;
    }

    private IEnumerator AnimationCoroutine()
    {
        _textComponent.ForceMeshUpdate();
        yield return new WaitForEndOfFrame();

        TMP_TextInfo textInfo = _textComponent.textInfo;

        int totalVisibleCharacters = textInfo.characterCount;
        int visibleCount = 0;

        _isAnimating = true;

        if (charsPerSecond == 0)
        {
            _isAnimating = false;
            yield break;
        }

        for (int i = 0; i < textInfo.linkCount; i++)
        {
            if (textInfo.linkInfo[i].GetLinkID() == "start from")
            {
                visibleCount = textInfo.linkInfo[i].linkTextfirstCharacterIndex;
                break;
            }
        }        

        while (true)
        {
            if (visibleCount > totalVisibleCharacters)
            {
                _isAnimating = false;
                yield break;
            }

            _textComponent.maxVisibleCharacters = visibleCount;

            visibleCount++;

            yield return new WaitForSecondsRealtime(1 / charsPerSecond);
        }
    }
}
