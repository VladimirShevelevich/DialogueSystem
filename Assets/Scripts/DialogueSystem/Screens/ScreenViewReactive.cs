using UniRx;

public class ScreenViewReactive
{
    public readonly ReactiveCommand Hide = new();
    public readonly ReactiveCommand OnHidden = new();
}