using System;
using UnityEngine;
using UnityEngine.UI;

namespace Novella.Dialog.Act
{
    public class Actor : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private DialogCharacter _dialogCharacter = null;
        private StageForActors _stage = null;
        private RectTransform _stageRectTransform = null;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _stage = FindObjectOfType<StageForActors>();
            _stageRectTransform = _stage.GetComponent<RectTransform>();
        }

        public DialogCharacter Character => _dialogCharacter;

        public void Instialize(DialogCharacter dialogCharacter)
        {
            _dialogCharacter = dialogCharacter;

            Image imageComponent = gameObject.AddComponent<Image>();
            imageComponent.sprite = _dialogCharacter.BodyImage;
            imageComponent.SetNativeSize();

            transform.SetParent(_stage.transform);
        }

        public void ApplyTransition(DialogCharacterState transition)
        {
            if (_rectTransform == null) _rectTransform = GetComponent<RectTransform>();
            Vector2 scale = _rectTransform.localScale; // null refrence
            if (transition.flipHorizontally)
                _rectTransform.localScale = new Vector2(-scale.x, scale.y);

            if (transition.flipVertically)
                _rectTransform.localScale = new Vector2(scale.x, -scale.y);

            if (transition.isDarkened) Darken();
            else Lighten();

            Move(transition.relativePosition, transition.transitionType);
        }

        private void Darken()
        {

        }

        private void Lighten()
        {

        }

        private void Move(Vector2 relativePosition, TransitionType transitionType = TransitionType.None)
        {
            Vector2 destination = new Vector2(_stage.Width * relativePosition.x, _stage.Height * relativePosition.y);

            Debug.Log($"{_stage.Width}, {_stage.Height}");

            switch (transitionType)
            {
                case TransitionType.None:
                    _rectTransform.anchoredPosition = destination;
                    break;
                case TransitionType.Linear:
                    break;
                case TransitionType.Smooth:
                    break;
                case TransitionType.AppearFromLeft:
                    break;
                case TransitionType.LeaveToLeft:
                    break;
                case TransitionType.AppearFromRight:
                    break;
                case TransitionType.LeaveToRight:
                    break;
                case TransitionType.FadeIn:
                    break;
                case TransitionType.FadeOut:
                    break;
                case TransitionType.AppearFromBottom:
                    break;
                case TransitionType.LeaveToBottom:
                    break;
                case TransitionType.AppearFromTop:
                    break;
                case TransitionType.LeaveToTop:
                    break;
                default:
                    new NotImplementedException("the transition type you are trying to use is not implemented");
                    break;
            }
        }
    }
}
