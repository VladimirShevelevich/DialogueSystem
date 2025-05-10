using UI;
using UI.Screens;
using UniRx;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class PuzzleChooseScreenView : DialogueScreenBaseView
{
    [SerializeField] private Button _nextButton;
    
    private PuzzleChooseScreenViewReactive _viewReactive;

    public void Init(PuzzleChooseScreenViewReactive viewReactive)
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
