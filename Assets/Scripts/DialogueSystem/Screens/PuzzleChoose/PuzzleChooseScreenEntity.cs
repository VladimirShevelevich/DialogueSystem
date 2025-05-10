using System;
using Content;
using UI.Screens.PuzzleChoose;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI
{
    public class PuzzleChooseScreenEntity : IDisposable
    {   
        private PuzzleChooseScreenView _view;

        public PuzzleChooseScreenEntity(
            ContentProvider contentProvider,
            Canvas uiCanvas,
            ReactiveCommand onHidden)
        {
            var viewReactive = new PuzzleChooseScreenViewReactive();
            viewReactive.OnHidden.Subscribe(_ => onHidden.Execute());
            
            new PuzzleChooseScreenViewModel(viewReactive);
            CreateView(contentProvider, viewReactive, uiCanvas);
        }

        private void CreateView(ContentProvider contentProvider, PuzzleChooseScreenViewReactive viewReactive, Canvas canvas)
        {
            _view = Object.Instantiate(contentProvider.PuzzleChooseScreenView, canvas.transform);
            _view.Init(viewReactive);
        }

        public void Dispose()
        {
            Object.Destroy(_view.gameObject);
        }
    }
}