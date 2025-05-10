using UniRx;

public abstract class DialogueScreenViewModel
{
    public readonly ReactiveCommand Hide = new();
    public readonly ReactiveCommand OnHidden = new();
}