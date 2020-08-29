using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Novella.Dialog.Act
{
    [Serializable]
    public class Actor : MonoBehaviour
    {
        #region Fields and Properties

        public DialogCharacter character;
        public ActorState currentState;
        public List<Transition> transitions;

        private RectTransform _rectTransform;
        private StageForActors _stage;
        private Image _image;
        private RectTransform _parentCanvasRectTransform;

        public int TransitionCount => transitions.Count;

        #endregion

        #region Public Methods

        // should probably change it for constructor
        public void Initialize(ActorToCreate actorToCreate)
        {
            character = actorToCreate.Character;
            currentState = actorToCreate.InitialState;
            transitions = actorToCreate.Transitions;

            Canvas parentCanvas = GetComponentInParent<Canvas>();
            _parentCanvasRectTransform = parentCanvas.GetComponent<RectTransform>();

            _rectTransform = gameObject.AddComponent<RectTransform>();

            _stage = transform.GetComponent<StageForActors>();

            _image = gameObject.AddComponent<Image>();
            _image.sprite = character.BodySprite;
            _image.SetNativeSize();
            SetImageScale();

            gameObject.name = character.name + " Actor";

            Move(currentState.relativePosition);
        }

        public void ApplyTransition(int index)
        {
            if (_stage == null) _stage = transform.parent.GetComponent<StageForActors>();

            if (index >= TransitionCount) return;

            if (transitions[index] == null) return;

            ActorState nextState = transitions[index].actorState;

            Move(nextState.relativePosition, transitions[index].type);

            Flip(nextState.flip);

            Scale(nextState.scale);

            Darken(nextState.darkness);

            ChangeOpacity(nextState.opacity);
        }

        #endregion

        #region Private Methods

        private void Move(Vector2 relativePosition, TransitionMoveType moveType = TransitionMoveType.None)
        {
            Vector2 canvasScale = _parentCanvasRectTransform.localScale;
            float destinationX = _stage.Width * relativePosition.x / canvasScale.x;
            float destinationY = _stage.Height * relativePosition.y / canvasScale.y;
            Vector2 destination = new Vector2(destinationX, destinationY) / 2;

            switch (moveType)
            {
                case TransitionMoveType.None:
                    //break;
                case TransitionMoveType.Instant:
                    currentState.position = destination;
                    currentState.relativePosition = relativePosition;
                    _rectTransform.anchoredPosition = destination;
                    break;
                case TransitionMoveType.Linear:
                    // not implemented
                    break;
                case TransitionMoveType.Smooth:
                    // not implemented
                    break;
            }
        }

        private void Scale(float scale)
        {
            SetImageScale();
            _rectTransform.localScale *= scale;
        }

        private void Flip(bool flip)
        {
            Vector2 scale = _rectTransform.localScale;

            bool alreadyFlipped = scale.x < 0;

            if ((flip && !alreadyFlipped) || (!flip && alreadyFlipped))
            {
                _rectTransform.localScale = new Vector2(-scale.x, scale.y);
            }
        }

        private void Darken(float darkness)
        {
            float lightness = 1 - darkness;
            _image.color = new Color(lightness, lightness, lightness);
        }

        private void ChangeOpacity(float opacity)
        {
            Color color = _image.color;
            _image.color = new Color(color.r, color.g, color.b, opacity);
        }

        // this method exists so that character's image would
        // have the same size on any resolution relative to canvas
        private void SetImageScale()
        {
            // assuming we set image component and got rect transform
            // and canvas rect transform and called SetNativeSize().
            // for completely identical look on all resolutions canvas scaler should match height

            float canvasHeight = _parentCanvasRectTransform.sizeDelta.y;
            float canvasScale = _parentCanvasRectTransform.localScale.y;
            float actualCanvasHeight = canvasHeight * canvasScale;

            // i use 1080 since my monitor is full hd, but any number would fit
            float scaleFactor = actualCanvasHeight / 1080f;
            _rectTransform.localScale *= scaleFactor;
        }

        #endregion

    }
}