using UniRx;

namespace UI.Screens.PuzzleChoose
{
    public class PuzzleChooseScreenViewModel
    {
        private readonly PuzzleChooseScreenViewReactive _viewReactive;

        public PuzzleChooseScreenViewModel(PuzzleChooseScreenViewReactive viewReactive)
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