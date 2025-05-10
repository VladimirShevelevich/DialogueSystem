namespace UI
{
    public class LevelSetupModel
    {
        public PuzzleID ChosenPuzzleID {get; private set;}
        public int ChosenLayout { get; private set; }

        public void SetPuzzleID(PuzzleID puzzleID)
        {
            ChosenPuzzleID = puzzleID;
        }

        public void SetLayout(int chosenLayoutValue)
        {
            ChosenLayout = chosenLayoutValue;
        }

        public override string ToString()
        {
            return $"Puzzle ID: {ChosenPuzzleID}, Layout: {ChosenLayout}";
        }
    }
}