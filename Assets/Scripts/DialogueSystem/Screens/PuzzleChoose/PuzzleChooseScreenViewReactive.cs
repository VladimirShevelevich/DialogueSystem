using System;
using UniRx;

namespace UI
{
    public enum PuzzleID
    {
        Dog,
        Cat,
        Fish
    }
    
    public class PuzzleChooseScreenViewReactive : ScreenViewReactive
    {
        public readonly ReactiveProperty<PuzzleID> ChosenPuzzleID = new(PuzzleID.Dog);
        public readonly ReactiveCommand<PuzzleID> OnPuzzleClicked = new();
        public readonly ReactiveCommand OnNextScreenClicked = new();
    }
}