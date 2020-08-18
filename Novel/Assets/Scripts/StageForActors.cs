using UnityEngine;

namespace Novella.Dialog.Act
{
    public class StageForActors : MonoBehaviour
    {
        private RectTransform _rectTransform;

        public float Width => Screen.width + _rectTransform.sizeDelta.x;
        public float Height => Screen.height + _rectTransform.sizeDelta.y;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

    }
}
