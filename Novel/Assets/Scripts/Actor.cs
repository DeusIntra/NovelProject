using System;
using UnityEngine;
using UnityEngine.UI;

namespace Novella.Dialog.Act
{
    public class Actor : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private DialogCharacter _dialogCharacter = null;

        public void Instialize(DialogCharacter dialogCharacter)
        {
            _dialogCharacter = dialogCharacter;

            Image imageComponent = gameObject.AddComponent<Image>();

            imageComponent.sprite = _dialogCharacter.BodyImage;
        }

        public void Move(Vector2 position, TransitionType transitionType = TransitionType.None)
        {
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
