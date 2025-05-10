using UI.Screens.LayoutChoose;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(fileName = "ContentProvider", menuName = "Content/ContentProvider", order = 0)]
    public class ContentProvider : ScriptableObject
    {
        [SerializeField] public PuzzleChooseScreenView PuzzleChooseScreenView;
        [SerializeField] public LayoutChooseScreenView layoutChooseScreenView;
    }
}