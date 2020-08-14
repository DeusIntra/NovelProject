using System.Collections;
using TMPro;
using UnityEngine;
using Novella.Dialog;

public class TextWordAnimation : MonoBehaviour, ITextAnimation
{
    private bool _isAnimating;
    private TMP_Text _text;
    private float _speed;
    private Coroutine _coroutine;

    public bool isAnimating()
    {
        return _isAnimating;
    }

    public void Animate(TMP_Text text, float speed)
    {
        _text = text;
        _speed = speed;
        _coroutine = StartCoroutine(AnimationCoroutine());
    }

    public void StopAnimation()
    {
        _isAnimating = false;
        StopCoroutine(_coroutine);
        _text.maxVisibleCharacters = _text.textInfo.characterCount;
    }

    private IEnumerator AnimationCoroutine()
    {
        _text.ForceMeshUpdate();

        TMP_TextInfo textInfo = _text.textInfo;
        TMP_WordInfo[] wordInfo = textInfo.wordInfo;

        int totalVisibleCharacters = textInfo.characterCount;
        int totalWordCount = textInfo.wordCount;
        int visibleCount = 0;
        int currentWord = 0;

        _isAnimating = true;

        if (_speed == 0)
        {
            _isAnimating = false;
            yield break;
        }

        TMP_LinkInfo[] links = textInfo.linkInfo;
        if (links.Length > 0)
        {
            for (int i = 0; i < links.Length; i++)
            {
                if (links[i].GetLinkID() == "start from")
                {
                    int firstIndex = links[i].linkTextfirstCharacterIndex;
                    
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
        }

        while (true)
        {
            if (currentWord == 0)
                visibleCount = 0;
            else if (currentWord < totalWordCount)
                visibleCount = textInfo.wordInfo[currentWord - 1].lastCharacterIndex + 1;
            else if (currentWord == totalWordCount)
                visibleCount = totalVisibleCharacters;

            _text.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                _isAnimating = false;
                yield break;
            }

            currentWord++;

            yield return new WaitForSeconds(1 / _speed);
        }
    }
}