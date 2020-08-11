using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public enum Side { Left, Right };

    #region Fields

    [Header("Header")]
    //[Tooltip("Tooltip")]
    public bool useFaceIcon;
    public Side faceIconSide;
    public bool useNameBox;
    public TextStyle DefaultTextStyle;
    // opening animation
    // closing animation
    // choice opening animation
    // choice closing
        
    [Space]
    [Header("Child GameObjects")]

    [SerializeField] private GameObject _body = null;
    [SerializeField] private GameObject _nameBox = null;
    [SerializeField] private GameObject _faceIconObject = null;
    [SerializeField] private GameObject _nextButton = null;
    [SerializeField] private GameObject _choicePanel = null;
    [SerializeField] private GameObject _choiceButtonPrefab = null;

    private TextMeshProUGUI _bodyText;
    private TextMeshProUGUI _nameText;
    private Image _faceIconImage;
    private RectTransform _bodyTextRectTransform;
    private RectTransform _faceIconRectTransform;
    private List<DialogNode.Choice> _choices;
    private List<GameObject> _choiceButtons;
    private DialogNode _currentNode;

    #endregion

    #region Unity methods

    private void Awake()
    {
        _bodyText = _body.GetComponentInChildren<TextMeshProUGUI>();
        _nameText = _nameBox.GetComponentInChildren<TextMeshProUGUI>();
        _faceIconImage = _faceIconObject.GetComponentInChildren<Image>();
        _bodyTextRectTransform = _bodyText.GetComponent<RectTransform>();
        _faceIconRectTransform = _faceIconObject.GetComponent<RectTransform>();
        _choices = new List<DialogNode.Choice>();
        _choiceButtons = new List<GameObject>();
        _currentNode = null;
    }

    #endregion

    #region Public methods

    public void Open(DialogNode firstNode)
    {
        gameObject.SetActive(true);
        StartDialog(firstNode);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void StartDialog(DialogNode firstNode = null)
    {
        if (firstNode != null) _currentNode = firstNode;
        PlayDialog();
    }

    // Used for "Next" button
    public void PlayDialog()
    {
        if (_currentNode == null) // should close dialog box if null
        {
            Close();
            return;
        }

        Quote quote = _currentNode.NextQuote();

        if (quote == null) // should present choices
        {
            if (_currentNode.Choices.Count > 0)
            {
                PresentChoices();
            }
            else if (_currentNode.NextNode != null)
            {
                _currentNode = _currentNode.NextNode;
                PlayDialog();
            }
            else
            {
                Close();
            }

            return;
        }

        ShowFaceIcon(quote);
        SetFontAndColor(quote);

        _nameBox.SetActive(quote.CharacterName != "" && useNameBox);

        _nameText.text = quote.CharacterName;
        _bodyText.text = quote.Text;
    }

    public void SetNode(DialogNode nextNode)
    {
        _currentNode = nextNode;
        _nextButton.SetActive(true);
        DestroyChoices();
        PlayDialog();
    }

    #endregion

    #region Private methods

    private void PresentChoices()
    {
        _body.SetActive(false);
        _nameBox.SetActive(false);
        _nextButton.SetActive(false);

        _choices = _currentNode.Choices;
        // for each choice create button as a child of choice panel
        foreach (var choice in _choices)
        {
            GameObject buttonObject = Instantiate(_choiceButtonPrefab, _choicePanel.transform);
            TextMeshProUGUI buttonText = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            Button button = buttonObject.GetComponent<Button>();
                
            buttonText.text = choice.Text;
            button.onClick.AddListener(delegate { SetNode(choice.NextNode); });

            if (choice.OnChoice != null)
                button.onClick.AddListener(choice.OnChoice.Raise);
        }

        _choicePanel.SetActive(true);
    }

    private void DestroyChoices()
    {
        foreach (GameObject button in _choiceButtons)
        {
            Destroy(button);
        }

        _choicePanel.SetActive(false);

        _body.SetActive(true);
        _nameBox.SetActive(true);
        _nextButton.SetActive(true);
    }

    private void ShowFaceIcon(Quote quote)
    {
        Sprite faceSprite = quote.FaceIcon;
        if (!useFaceIcon || faceSprite == null)
        {
            _faceIconObject.SetActive(false);

            _bodyTextRectTransform.anchoredPosition = new Vector2(0, -10);
            _bodyTextRectTransform.sizeDelta = new Vector2(-60, -20);
            return;
        }

        _faceIconObject.SetActive(true);

        _faceIconImage.sprite = faceSprite;

        _bodyTextRectTransform.sizeDelta = new Vector2(-320, -30);

        switch (faceIconSide)
        {
            case Side.Left:
                _faceIconRectTransform.anchorMin = Vector2.zero;
                _faceIconRectTransform.anchorMax = new Vector2(0, 1);

                _faceIconRectTransform.anchoredPosition = new Vector2(80, 0);
                _faceIconRectTransform.sizeDelta = new Vector2(140, -20);

                _bodyTextRectTransform.anchoredPosition = new Vector2(75, -10);
                _bodyTextRectTransform.sizeDelta = new Vector2(-210, -20);

                break;

            case Side.Right:
                _faceIconRectTransform.anchorMin = new Vector2(1, 0);
                _faceIconRectTransform.anchorMax = new Vector2(1, 1);

                _faceIconRectTransform.anchoredPosition = new Vector2(-80, 0);
                _faceIconRectTransform.sizeDelta = new Vector2(140, -20);

                _bodyTextRectTransform.anchoredPosition = new Vector2(-75, -10);
                _bodyTextRectTransform.sizeDelta = new Vector2(-210, -20);

                break;

            default: 
                // don't judge me plz
                break;
        }            
    }

    private void SetFontAndColor(Quote quote)
    {
        _bodyText.font = quote.Font ?? DefaultTextStyle.Font;
        _bodyText.fontSize = quote.FontSize != 0 ? quote.FontSize : DefaultTextStyle.FontSize;
        _bodyText.color = quote.TextColor ?? DefaultTextStyle.TextColor;
    }

    [ContextMenu("RT")]
    private void test()
    {
        //_bodyText = _body.GetComponentInChildren<TextMeshProUGUI>();
        var RT = _faceIconObject.GetComponent<RectTransform>();
        Debug.Log(
            //"Rect: " + RT.rect + "\n" + 
            "Anchored Pos: " + RT.anchoredPosition + "\n" +
            "Size Delta: " + RT.sizeDelta);
    }

    #endregion

}
