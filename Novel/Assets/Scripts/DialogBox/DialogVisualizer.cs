using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Novella.Dialog
{

    [RequireComponent(typeof(DialogPlayer))]
    public class DialogVisualizer : MonoBehaviour
    {
        public enum Side { Left, Right };

        public bool useNameBox;
        public bool useFaceImage;
        public Side faceImageSide;

        public TextStyle defaultTextStyle;

        [Header("Child GameObjects")]
        [SerializeField] private GameObject _body = null;
        [SerializeField] private GameObject _faceImageObject = null;
        [SerializeField] private GameObject _nameBox = null;
        [SerializeField] private GameObject _nextButton = null;
        [SerializeField] private GameObject _choicePanel = null;
        [SerializeField] private GameObject _choiceButtonPrefab = null;

        private DialogPlayer _dialogPlayer;
        private TextMeshProUGUI _bodyText;
        private TextMeshProUGUI _nameText;
        private Image _faceImage;
        private RectTransform _bodyTextRectTransform;
        private RectTransform _faceImageRectTransform;

        private void Awake()
        {
            _dialogPlayer = GetComponent<DialogPlayer>();
            _bodyText = _body.GetComponentInChildren<TextMeshProUGUI>();
            _nameText = _nameBox.GetComponentInChildren<TextMeshProUGUI>();
            _faceImage = _faceImageObject.GetComponent<Image>();
            _bodyTextRectTransform = _bodyText.GetComponent<RectTransform>();
            _faceImageRectTransform = _faceImage.GetComponent<RectTransform>();
        }

        public void ShowFaceIcon(Quote quote)
        {
            Sprite faceSprite = quote.FaceIcon;
            if (!useFaceImage || faceSprite == null)
            {
                _faceImageObject.SetActive(false);

                _bodyTextRectTransform.anchoredPosition = new Vector2(0, -10);
                _bodyTextRectTransform.sizeDelta = new Vector2(-60, -20);
                return;
            }

            _faceImageObject.SetActive(true);

            _faceImage.sprite = faceSprite;

            _bodyTextRectTransform.sizeDelta = new Vector2(-320, -30);

            switch (faceImageSide)
            {
                case Side.Left:
                    _faceImageRectTransform.anchorMin = Vector2.zero;
                    _faceImageRectTransform.anchorMax = new Vector2(0, 1);

                    _faceImageRectTransform.anchoredPosition = new Vector2(80, 0);
                    _faceImageRectTransform.sizeDelta = new Vector2(140, -20);

                    _bodyTextRectTransform.anchoredPosition = new Vector2(75, -10);
                    _bodyTextRectTransform.sizeDelta = new Vector2(-210, -20);

                    break;

                case Side.Right:
                    _faceImageRectTransform.anchorMin = new Vector2(1, 0);
                    _faceImageRectTransform.anchorMax = new Vector2(1, 1);

                    _faceImageRectTransform.anchoredPosition = new Vector2(-80, 0);
                    _faceImageRectTransform.sizeDelta = new Vector2(140, -20);

                    _bodyTextRectTransform.anchoredPosition = new Vector2(-75, -10);
                    _bodyTextRectTransform.sizeDelta = new Vector2(-210, -20);

                    break;

                default:
                    // don't judge me plz
                    break;
            }
        }

        public void SetTextStyle(Quote quote)
        {
            _bodyText.font = quote.Font ?? defaultTextStyle.Font;
            _bodyText.fontSize = quote.FontSize != 0 ? quote.FontSize : defaultTextStyle.FontSize;
            _bodyText.color = quote.TextColor ?? defaultTextStyle.TextColor;
        }

        public void SetText(Quote quote)
        {
            _nameBox.SetActive(quote.CharacterName != "" && useNameBox);
            _nameText.text = quote.CharacterName;
            _bodyText.text = quote.Text;
        }

        public void ShowDialogBox()
        {
            _body.SetActive(true);
            _nameBox.SetActive(true);
            _nextButton.SetActive(true);
        }

        public void HideDialogBox()
        {
            _body.SetActive(false);
            _nameBox.SetActive(false);
            _nextButton.SetActive(false);
        }

        public void PresentChoices(List<DialogNode.Choice> choices)
        {
            _nextButton.SetActive(false);
            HideDialogBox();

            // for each choice create button as a child of choice panel
            foreach (var choice in choices)
            {
                GameObject buttonObject = Instantiate(_choiceButtonPrefab, _choicePanel.transform);
                TextMeshProUGUI buttonText = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
                Button button = buttonObject.GetComponent<Button>();

                buttonText.text = choice.Text;
                button.onClick.AddListener(delegate
                {
                    _dialogPlayer.SetNode(choice.NextNode);
                    _nextButton.SetActive(true);
                    DestroyChoices();
                    ShowDialogBox();
                });

                if (choice.OnChoice != null)
                    button.onClick.AddListener(choice.OnChoice.Raise);
            }

            _choicePanel.SetActive(true);
        }

        public void DestroyChoices()
        {
            foreach (Transform button in _choicePanel.transform)
            {
                Destroy(button.gameObject);
            }

            _choicePanel.SetActive(false);

            ShowDialogBox();
        }
    }
}
