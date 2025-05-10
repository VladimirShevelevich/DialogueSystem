using UniRx;

namespace UI.Screens.PuzzleChoose
{
    public class PuzzleChooseScreenViewModel : DialogueScreenViewModel
    {
        public readonly ReactiveProperty<PuzzleChooseScreenEntity.PuzzleID> ChosenPuzzleID = new(PuzzleChooseScreenEntity.PuzzleID.Dog);
        public readonly ReactiveCommand<PuzzleChooseScreenEntity.PuzzleID> OnPuzzleClicked = new();
        public readonly ReactiveCommand OnNextScreenClicked = new();

        public PuzzleChooseScreenViewModel()
        {
            OnNextScreenClicked.Subscribe(_ => HandleOnNextScreenClicked());
        }

        private void HandleOnNextScreenClicked()
        {
            Hide.Execute();
        }
    }
}