using UniRx;

namespace UI.Screens.LayoutChoose
{
    public class LayoutChooseScreenViewReactive : ScreenViewReactive
    {
        public readonly ReactiveCommand OnNextScreenClicked = new();
    }
}