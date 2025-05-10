using UniRx;

public abstract class DialogueScreenViewModel
{
    public readonly ReactiveCommand Hide = new();
    public readonly ReactiveCommand OnHidden = new();
    public readonly ReactiveCommand OnNextScreenClicked = new();
    public readonly ReactiveProperty<bool> NextButtonAvailable = new();
}