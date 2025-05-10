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
        [SerializeField] private LayoutView[] _layoutViews;

        public void Init(LayoutChooseScreenViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.Hide.Subscribe(_=> Hide());
            _viewModel.ChosenLayout.Subscribe(HandleLayoutChosen);
            _nextButton.OnClickAsObservable().Subscribe(_=> 
                viewModel.OnNextScreenClicked.Execute());
        
            InitLayoutViews();
            Show();
        }
        
        private void InitLayoutViews()
        {
            foreach (var layoutView in _layoutViews)
            {
                layoutView.OnClick += () => _viewModel.OnLayoutClicked.Execute(layoutView.Layout);
            }
        }

        private void HandleLayoutChosen(int chosenLayout)
        {
            foreach (var layoutView in _layoutViews)
            {
                layoutView.Highlight(chosenLayout == layoutView.Layout);
            }
        }

        private void HandleNextButtonAvailable(bool available)
        {
            _nextButton.gameObject.SetActive(available);
        }

        protected override void OnHidden()
        {
            _viewModel.OnHidden.Execute();
        }
    }
}