using System;
using UnityEngine;
using UnityEngine.UI;

namespace Novella.Dialog.Act
{
    public class Actor : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private DialogCharacter _dialogCharacter = null;
        private GameObject _parent = null;
        private RectTransform _parentRectTransform = null;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _parent = GameObject.FindWithTag("Stage for Actors"); // find by script
            _parentRectTransform = _parent.GetComponent<RectTransform>();
        }

        public DialogCharacter Character => _dialogCharacter;

        public void Instialize(DialogCharacter dialogCharacter)
        {
            _dialogCharacter = dialogCharacter;

            Image imageComponent = gameObject.AddComponent<Image>();
            imageComponent.sprite = _dialogCharacter.BodyImage;            
        }

        public void ApplyTransition(DialogCharacterState transition)
        {
            if (transition.flipHorizontally)
            {

            }

            if (transition.flipVertically)
            {

            }

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
            float panelWidth = Screen.width + _parentRectTransform.sizeDelta.x;
            float panelHeight = Screen.width + _parentRectTransform.sizeDelta.y;
            Vector2 destination;
            switch (transitionType)
            {
                case TransitionType.None:
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
