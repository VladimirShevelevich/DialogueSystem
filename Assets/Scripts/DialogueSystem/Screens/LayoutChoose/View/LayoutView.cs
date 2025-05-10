using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.LayoutChoose
{
    public class LayoutView : MonoBehaviour
    {
        public int Layout;
        public event Action OnClick = delegate { };
        
        [SerializeField] private Image HighlightBorder;
        [SerializeField] private Button Button;

        private void Awake()
        {
            Button.onClick.AddListener(() => OnClick.Invoke());
        }

        public void Highlight(bool active)
        {
            HighlightBorder.enabled = active;
        }
    }
}