﻿using System;
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
            ReactiveCommand onHidden,
            LevelSetupModel levelSetupModel)
        {
            var viewModel = new PuzzleChooseScreenViewModel(levelSetupModel);
            viewModel.OnHidden.Subscribe(_=> onHidden.Execute());
            CreateView(contentProvider, viewModel, uiCanvas);
        }

        private void CreateView(ContentProvider contentProvider, PuzzleChooseScreenViewModel viewModel, Canvas canvas)
        {
            _view = Object.Instantiate(contentProvider.PuzzleChooseScreenView, canvas.transform);
            _view.Init(viewModel);
        }

        public void Dispose()
        {
            Object.Destroy(_view.gameObject);
        }
    }
}