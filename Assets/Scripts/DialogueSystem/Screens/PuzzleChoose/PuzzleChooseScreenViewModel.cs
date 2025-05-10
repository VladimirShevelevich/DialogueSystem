using UniRx;

namespace UI.Screens.PuzzleChoose
{
    public class PuzzleChooseScreenViewModel : DialogueScreenViewModel
    {
        public readonly ReactiveProperty<PuzzleID> ChosenPuzzleID = new();
        public readonly ReactiveCommand<PuzzleID> OnPuzzleClicked = new();
        
        private readonly LevelSetupModel _levelSetupModel;

        public PuzzleChooseScreenViewModel( LevelSetupModel levelSetupModel)
        {
            _levelSetupModel = levelSetupModel;
            OnNextScreenClicked.Subscribe(_=> HandleOnNextScreenClicked());
            
            OnPuzzleClicked.Subscribe(HandlePuzzleClicked);
        }

        private void HandlePuzzleClicked(PuzzleID puzzleID)
        {
            ChosenPuzzleID.Value = puzzleID;
            NextButtonAvailable.Value = true;
        }

        private void HandleOnNextScreenClicked()
        {
            _levelSetupModel.SetPuzzleID(ChosenPuzzleID.Value);
            Hide.Execute();
        }
    }
}