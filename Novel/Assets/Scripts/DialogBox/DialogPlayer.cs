using TMPro;
using UnityEngine;

[RequireComponent(typeof(DialogVisualizer))]
public class DialogPlayer : MonoBehaviour
{
    public float animationSpeed = 15;

    [SerializeField] private TextMeshProUGUI _bodyText = null;
    [SerializeField] private TextAnimationHolder _textAnimHolder = null;
    [SerializeField] private TextEffectHolder _textEffectHolder = null;
    [SerializeField] private DialogBoxAnimationHolder _dialogAnimHolder = null;

    private ITextAnimation _textAnimation;
    private IDialogBoxAnimation _dialogBoxAnimation;
    private DialogNode _currentNode;
    private DialogVisualizer _dialogVisualizer;

    private void Awake()
    {
        _dialogVisualizer = GetComponent<DialogVisualizer>();
        _textAnimation = _textAnimHolder.CurrentAnimation;
        _dialogBoxAnimation = _dialogAnimHolder.CurrentAnimation;
    }

    public void StartDialog(DialogNode firstNode)
    {
        _currentNode = firstNode;
        _dialogBoxAnimation.Open(gameObject);
        PlayDialog();
    }

    public void PlayDialog()
    {
        if (_dialogBoxAnimation.isAnimating())
        {
            return;
        }

        if (_textAnimation.isAnimating())
        {
            _textAnimation.StopAnimation();
            return;
        }
        else
        {
            _textEffectHolder.TerminateAll();
        }

        if (_currentNode is null)
        {
            _dialogBoxAnimation.Close(gameObject);
        }

        Quote quote = _currentNode.NextQuote();

        if (quote == null) // if node is finished
        {
            if (_currentNode.Choices.Count > 0)
            {
                _dialogVisualizer.PresentChoices(_currentNode.Choices);
            }
            else if (_currentNode.NextNode != null)
            {
                _currentNode = _currentNode.NextNode;
                PlayDialog();
            }
            else
            {
                _dialogBoxAnimation.Close(gameObject);
            }
            return;
        }

        _dialogVisualizer.ShowFaceIcon(quote);
        _dialogVisualizer.SetTextStyle(quote);
        _dialogVisualizer.SetText(quote);

        _textAnimation.Animate(_bodyText, animationSpeed);
        _textEffectHolder.ApplyAll(_bodyText);
    }

    // used for choice buttons
    public void SetNode(DialogNode nextNode)
    {
        _currentNode = nextNode;
        PlayDialog();
    }
}
