using DialogueSystem.Screens.LayoutChoose;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.LayoutChoose
{
    public class LayoutChooseScreenView : DialogueScreenBaseView
    {
        [SerializeField] private Button _nextButton;
        private LayoutChooseScreenViewModel _viewModel;

        public void Init(LayoutChooseScreenViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.Hide.Subscribe(_=> Hide());
            _nextButton.OnClickAsObservable().Subscribe(_=> 
                viewModel.OnNextScreenClicked.Execute());
        
            Show();
        }

        protected override void OnHidden()
        {
            _viewModel.OnHidden.Execute();
        }
    }
}