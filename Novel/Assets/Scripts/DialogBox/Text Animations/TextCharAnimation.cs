using System.Collections;
using TMPro;
using UnityEngine;
using Novella.Dialog;

public class TextCharAnimation : MonoBehaviour, ITextAnimation
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

        int totalVisibleCharacters = textInfo.characterCount;
        int visibleCount = 0;

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
                    visibleCount = links[i].linkTextfirstCharacterIndex;
                    break;
                }
            }
        }

        while (true)
        {
            if (visibleCount > totalVisibleCharacters)
            {
                _isAnimating = false;
                yield break;
            }

            _text.maxVisibleCharacters = visibleCount;

            visibleCount++;

            yield return new WaitForSeconds(1 / _speed);
        }
    }
}
