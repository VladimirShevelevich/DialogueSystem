using DialogueSystem.Screens.PuzzleChoose;
using UI;
using UI.Screens;
using UI.Screens.PuzzleChoose;
using UniRx;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class PuzzleChooseScreenView : DialogueScreenBaseView
{
    [SerializeField] private Button _nextButton;
    [SerializeField] private PuzzleView[] _puzzleViews;
    
    private PuzzleChooseScreenViewModel _viewModel;

    public void Init(PuzzleChooseScreenViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.Hide.Subscribe(_=> Hide());
        _viewModel.ChosenPuzzleID.Subscribe(HandlePuzzleChosen);
        _viewModel.NextButtonAvailable.Subscribe(HandleNextButtonAvailable);
        _nextButton.OnClickAsObservable().Subscribe(_=> 
            viewModel.OnNextScreenClicked.Execute());
        
        InitPuzzleViews();
        Show();
    }

    private void InitPuzzleViews()
    {
        foreach (var puzzleView in _puzzleViews)
        {
            puzzleView.OnClick += () => _viewModel.OnPuzzleClicked.Execute(puzzleView.PuzzleID);
        }
    }

    private void HandlePuzzleChosen(PuzzleID chosenPuzzle)
    {
        foreach (var puzzleView in _puzzleViews)
        {
            puzzleView.Highlight(chosenPuzzle == puzzleView.PuzzleID);
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
