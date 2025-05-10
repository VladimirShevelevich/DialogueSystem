using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem.Screens.PuzzleChoose
{
    public class PuzzleView : MonoBehaviour
    {
        public PuzzleChooseScreenEntity.PuzzleID PuzzleID;
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