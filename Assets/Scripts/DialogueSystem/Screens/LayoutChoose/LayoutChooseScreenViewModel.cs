using UI.Screens.LayoutChoose;
using UniRx;

namespace DialogueSystem.Screens.LayoutChoose
{
    public class LayoutChooseScreenViewModel
    {
        private readonly LayoutChooseScreenViewReactive _viewReactive;
        public readonly ReactiveCommand OnNextScreenClicked = new();

        public LayoutChooseScreenViewModel(LayoutChooseScreenViewReactive viewReactive)
        {
            _viewReactive = viewReactive;
            _viewReactive.OnNextScreenClicked.Subscribe(_ => HandleOnNextScreenClicked());
        }

        private void HandleOnNextScreenClicked()
        {
            _viewReactive.Hide.Execute();
        }
    }
}