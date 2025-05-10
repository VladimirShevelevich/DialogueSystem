using UI;
using UI.Screens.LayoutChoose;
using UniRx;

namespace DialogueSystem.Screens.LayoutChoose
{
    public class LayoutChooseScreenViewModel : DialogueScreenViewModel
    {
        public readonly ReactiveProperty<int> ChosenLayout= new();
        public readonly ReactiveCommand<int> OnLayoutClicked = new();
        
        private readonly LevelSetupModel _levelSetupModel;
        
        public LayoutChooseScreenViewModel(LevelSetupModel levelSetupModel)
        {
            _levelSetupModel = levelSetupModel;
            OnNextScreenClicked.Subscribe(_ => HandleOnNextScreenClicked());
            OnLayoutClicked.Subscribe(HandleLayoutClicked);
        }

        private void HandleLayoutClicked(int chosenLayout)
        {
            ChosenLayout.Value = chosenLayout;
            NextButtonAvailable.Value = true;
        }

        private void HandleOnNextScreenClicked()
        {
            _levelSetupModel.SetLayout(ChosenLayout.Value);
            Hide.Execute();
        }
    }
}