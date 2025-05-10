using UniRx;

namespace UI.Screens.PuzzleChoose
{
    public class PuzzleChooseScreenViewModel : DialogueScreenViewModel
    {
        public readonly ReactiveProperty<PuzzleChooseScreenEntity.PuzzleID> ChosenPuzzleID = new();
        public readonly ReactiveCommand<PuzzleChooseScreenEntity.PuzzleID> OnPuzzleClicked = new();
        public readonly ReactiveCommand OnNextScreenClicked = new();

        public PuzzleChooseScreenViewModel()
        {
            OnNextScreenClicked.Subscribe(puzzle => HandleOnNextScreenClicked());
            OnPuzzleClicked.Subscribe(HandlePuzzleClicked);
        }

        private void HandlePuzzleClicked(PuzzleChooseScreenEntity.PuzzleID puzzleID)
        {
            ChosenPuzzleID.Value = puzzleID;
        }

        private void HandleOnNextScreenClicked()
        {
            Hide.Execute();
        }
    }
}