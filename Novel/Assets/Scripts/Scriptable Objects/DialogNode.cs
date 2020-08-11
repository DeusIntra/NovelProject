using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog Node", menuName = "Scriptable Object/Dialog/Node", order = 52)]
public class DialogNode : ScriptableObject
{
    #region Internal classes

    [Serializable]
    public class Choice 
    {
        [SerializeField] private string _text = "";
        [SerializeField] private DialogNode _nextNode = null;
        [SerializeField] private GameEvent _onChoice = null;

        public string Text { get => _text; }
        public DialogNode NextNode { get => _nextNode; }
        public GameEvent OnChoice { get => _onChoice; }
    }

    #endregion

    #region Fields

    [SerializeField] private List<Quote> _quotes = new List<Quote>();
    [SerializeField] private List<Choice> _choices = null;
    [SerializeField] private DialogNode _nextNode = null;
    [SerializeField] private GameEvent _onEndNode = null;

    public List<Quote> Quotes { get => _quotes; }
    public List<Choice> Choices { get => _choices; }
    public Quote CurrentQuote { get => _quotes[_currentQuoteIndex]; }
    public DialogNode NextNode { get => _nextNode; }

    private int _currentQuoteIndex;

    public void OnEnable() 
    {
        _currentQuoteIndex = -1;
    }

    #endregion

    #region Public methods

    public Quote NextQuote() 
    {
        if (_quotes.Count == 0) throw new System.Exception("Dialog \"" + this.name + "\" has 0 quotes");

        if (++_currentQuoteIndex < _quotes.Count)
            return _quotes[_currentQuoteIndex];

        else
        {
            _currentQuoteIndex = -1;
            _onEndNode?.Raise();
            return null; // should present choices
        }
    }

    #endregion
}

