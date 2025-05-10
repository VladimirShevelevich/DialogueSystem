using UI.Screens.LayoutChoose;
using UniRx;

namespace DialogueSystem.Screens.LayoutChoose
{
    public class LayoutChooseScreenViewModel : DialogueScreenViewModel
    {
        public readonly ReactiveCommand OnNextScreenClicked = new();

        public LayoutChooseScreenViewModel()
        {
            OnNextScreenClicked.Subscribe(_ => HandleOnNextScreenClicked());
        }

        private void HandleOnNextScreenClicked()
        {
            Hide.Execute();
        }
    }
}