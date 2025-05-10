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
            var viewModel = new LayoutChooseScreenViewModel();
            viewModel.OnHidden.Subscribe(_=> onHidden.Execute());
            CreateView(contentProvider, viewModel, uiCanvas);
        }

        private void CreateView(ContentProvider contentProvider, LayoutChooseScreenViewModel viewModel, Canvas canvas)
        {
            _view = Object.Instantiate(contentProvider.layoutChooseScreenView, canvas.transform);
            _view.Init(viewModel);
        }

        public void Dispose()
        {
            Object.Destroy(_view);
        }
    }
}
