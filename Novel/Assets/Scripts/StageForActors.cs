using UnityEngine;

namespace Novella.Dialog.Act
{
    public class StageForActors : MonoBehaviour
    {
        public ActNode actNode;

        private RectTransform _rectTransform;

        public float Width => Screen.width + _rectTransform.sizeDelta.x;
        public float Height => Screen.height + _rectTransform.sizeDelta.y;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            actNode.Initialize(transform);
        }

        public void Next()
        {
            actNode.NextTransition();
        }

    }
}
