using UI;
using UI.Screens;
using UI.Screens.PuzzleChoose;
using UniRx;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class PuzzleChooseScreenView : DialogueScreenBaseView
{
    [SerializeField] private Button _nextButton;
    
    private PuzzleChooseScreenViewModel _viewModel;

    public void Init(PuzzleChooseScreenViewModel viewModel)
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
