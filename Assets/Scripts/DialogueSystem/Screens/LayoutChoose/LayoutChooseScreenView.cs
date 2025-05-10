using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.LayoutChoose
{
    public class LayoutChooseScreenView : DialogueScreenBaseView
    {
        [SerializeField] private Button _nextButton;
    
        private LayoutChooseScreenViewReactive _viewReactive;

        public void Init(LayoutChooseScreenViewReactive viewReactive)
        {
            _viewReactive = viewReactive;
            _viewReactive.Hide.Subscribe(_=> Hide());
            _nextButton.OnClickAsObservable().Subscribe(_=> 
                _viewReactive.OnNextScreenClicked.Execute());
        
            Show();
        }

        protected override void OnHidden()
        {
            _viewReactive.OnHidden.Execute();
        }
    }
}