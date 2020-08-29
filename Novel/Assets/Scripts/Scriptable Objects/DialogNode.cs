using Novella.Dialog.Act;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Novella.Dialog
{
    [CreateAssetMenu(fileName = "New Dialog Node", menuName = "Scriptable Object/Dialog/Node", order = 52)]
    public class DialogNode : ScriptableObject
    {
        #region Internal Classes

        [Serializable]
        public class Choice
        {
            [SerializeField] private string _text = "";
            [SerializeField] private DialogNode _nextNode = null;
            [SerializeField] private GameEvent _onChoice = null;

            public string Text => _text;
            public DialogNode NextNode => _nextNode;
            public GameEvent OnChoice => _onChoice;
        }

        #endregion

        #region Fields and Properties

        [SerializeField] private List<Quote> _quotes = new List<Quote>();
        [SerializeField] private TMP_FontAsset _nodeFont;
        [SerializeField] private List<Choice> _choices = null;
        [SerializeField] private ActNode _actNode = null;
        [SerializeField] private DialogNode _nextNode = null;
        [SerializeField] private GameEvent _onEndNode = null;

        public List<Quote> Quotes => _quotes;
        public List<Choice> Choices => _choices;
        public Quote CurrentQuote => _quotes[_currentQuoteIndex];
        public ActNode ActNode => _actNode;
        public DialogNode NextNode => _nextNode;

        private int _currentQuoteIndex;

        public void OnEnable()
        {
            _currentQuoteIndex = -1;
        }

        #endregion

        #region Public Methods

        public Quote NextQuote()
        {
            if (_quotes.Count == 0) throw new System.Exception("Dialog \"" + this.name + "\" has 0 quotes");

            if (++_currentQuoteIndex < _quotes.Count)
            {
                return _quotes[_currentQuoteIndex];
            }

            else
            {
                Reset();
                _onEndNode?.Raise();
                return null; // should present choices
            }
        }


        public void Reset()
        {
            _currentQuoteIndex = -1;
        }

        #endregion
    }
}
