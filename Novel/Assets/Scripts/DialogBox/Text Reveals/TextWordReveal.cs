using System.Collections;
using TMPro;
using UnityEngine;
using Novella.Dialog;

public class TextWordReveal : MonoBehaviour, ITextAnimation
{
    public float wordsPerSecond = 5f;

    private bool _isAnimating;
    private TMP_Text _textComponent;
    private Coroutine _coroutine;

    public bool isAnimating()
    {
        return _isAnimating;
    }

    public void Animate(TMP_Text textComponent)
    {
        _textComponent = textComponent;
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
        TMP_TextInfo textInfo = _textComponent.textInfo;
        TMP_WordInfo[] wordInfo = textInfo.wordInfo;

        int totalVisibleCharacters = textInfo.characterCount;
        int totalWordCount = textInfo.wordCount;
        int visibleCount = 0;
        int currentWord = 0;

        _isAnimating = true;

        if (wordsPerSecond == 0)
        {
            _isAnimating = false;
            yield break;
        }

        // find the first link with ID "start from"
        for (int i = 0; i < textInfo.linkCount; i++)
        {
            if (textInfo.linkInfo[i].GetLinkID() == "start from")
            {
                int firstIndex = textInfo.linkInfo[i].linkTextfirstCharacterIndex;
                    
                for (int j = 0; j < totalWordCount; j++)
                {
                    if (wordInfo[j].firstCharacterIndex >= firstIndex)
                    {
                        currentWord = j;
                        break;
                    }
                }
                break;
            }
        }        

        while (true)
        {
            if (currentWord == 0)
                visibleCount = 0;
            else if (currentWord < totalWordCount)
                visibleCount = textInfo.wordInfo[currentWord - 1].lastCharacterIndex + 1;
            else if (currentWord == totalWordCount)
                visibleCount = totalVisibleCharacters;

            _textComponent.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                _isAnimating = false;
                yield break;
            }

            currentWord++;

            yield return new WaitForSecondsRealtime(1 / wordsPerSecond);
        }
    }
}