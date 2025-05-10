using System;
using System.Collections.Generic;
using Content;
using UniRx;
using UnityEngine;

namespace UI
{
    public class DialogueSystem
    {
        private enum ScreenType
        {
            ChoosePuzzleScreen,
            ChooseLayoutScreen
        }

        private List<ScreenType> _screensSequence;
        private int _currentScreenIndex;
        private IDisposable _currentScreen;
        private readonly ContentProvider _contentProvider;
        private readonly Canvas _uiCanvas;

        private readonly ReactiveCommand _onScreenHidden = new();
        private readonly LevelSetupModel _levelSetupModel;

        public DialogueSystem(ContentProvider contentProvider, Canvas uiCanvas, LevelSetupModel levelSetupModel)
        {
            _contentProvider = contentProvider;
            _uiCanvas = uiCanvas;
            _levelSetupModel = levelSetupModel;
            Init();
        }
        
        private void Init()
        {
            CreateScreensSequence();
            _onScreenHidden.Subscribe(_ => HandleScreenHidden());
            CreateScreen(_currentScreenIndex);            
        }

        private void CreateScreensSequence()
        {
            _screensSequence = new List<ScreenType>
            {
                ScreenType.ChoosePuzzleScreen,
                ScreenType.ChooseLayoutScreen
            };
        }

        private void CreateScreen(int index)
        {
            _currentScreen = CreateScreenByType(_screensSequence[index]);
        }

        private IDisposable CreateScreenByType(ScreenType screenType)
        {
            switch (screenType)
            {
                case ScreenType.ChoosePuzzleScreen:
                    return new PuzzleChooseScreenEntity(
                        _contentProvider, _uiCanvas, _onScreenHidden, _levelSetupModel);
                case ScreenType.ChooseLayoutScreen:
                    return new LayoutChooseScreenEntity(
                        _contentProvider, _uiCanvas, _onScreenHidden, _levelSetupModel);
                default:
                    throw new ArgumentOutOfRangeException(nameof(screenType), screenType, null);
            }
        }

        private void HandleScreenHidden()
        {
            _currentScreen.Dispose();
            
            _currentScreenIndex++;
            if (_currentScreenIndex >= _screensSequence.Count)
            {
                OnSetupCompleted();
                return;
            }
            
            CreateScreen(_currentScreenIndex);
        }

        private void OnSetupCompleted()
        {
            Debug.Log($"Setup completed. {_levelSetupModel}");
        }
    }
}