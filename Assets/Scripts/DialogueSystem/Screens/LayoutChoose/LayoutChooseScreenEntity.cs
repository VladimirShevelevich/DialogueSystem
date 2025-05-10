using System;
using Content;
using DialogueSystem.Screens.LayoutChoose;
using UI.Screens.LayoutChoose;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI
{
    public class LayoutChooseScreenEntity : IDisposable
    {
        private LayoutChooseScreenView _view;

        public LayoutChooseScreenEntity(
            ContentProvider contentProvider,
            Canvas uiCanvas,
            ReactiveCommand onHidden)
        {
            var viewReactive = new LayoutChooseScreenViewReactive();
            viewReactive.OnHidden.Subscribe(_ => onHidden.Execute());

            var viewModel = new LayoutChooseScreenViewModel(viewReactive);
            CreateView(contentProvider, viewReactive, uiCanvas);
        }

        private void CreateView(ContentProvider contentProvider, LayoutChooseScreenViewReactive viewReactive, Canvas canvas)
        {
            _view = Object.Instantiate(contentProvider.layoutChooseScreenView, canvas.transform);
            _view.Init(viewReactive);
        }

        public void Dispose()
        {
            Object.Destroy(_view);
        }
    }
}
