using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpenTina
{
    internal class SnakeGameLogic : BaseGameLogic
    {
        private SnakeGameplayState _gameplayState = new SnakeGameplayState();
        private ShowTextState _showTextState = new(2f);

        private int _currentLevel = 0;

        private bool _newGamePending = false;


        public override void Update(float deltaTime)
        {
            if (_currentState != null && !_currentState.IsDone())
                return;

            if (_currentState == null || _currentState == _gameplayState && !_gameplayState._gameOver)
            {
                GoToNextLevel();
            }

            else if (_currentState == _gameplayState && _gameplayState._gameOver)
            {
                GoToGameOver();
            }

            else if (_currentState != _gameplayState && _newGamePending)
            {
                GoToNextLevel();
            }

            else if (_currentState != _gameplayState && !_newGamePending)
            {
                GoToGameplay();
            }
        }
        public override void OnArrowUp()
        {
            if (_currentState != _gameplayState) return;
            _gameplayState.SetDirection(SnakeDir.Up);
        }
        public override void OnArrowDown()
        {
            if (_currentState != _gameplayState) return;
            _gameplayState.SetDirection(SnakeDir.Down);
        }

        public override void OnArrowLeft()
        {
            if (_currentState != _gameplayState) return;
            _gameplayState.SetDirection(SnakeDir.Left);
        }

        public override void OnArrowRight()
        {
            if (_currentState != _gameplayState) return;
            _gameplayState.SetDirection(SnakeDir.Right);
        }

        public void GoToGameplay()
        {
            _gameplayState._level = _currentLevel;
            _gameplayState._fieldWidth = _screenWidth;
            _gameplayState._fieldHeight = _screenHeight;
            ChangeState(_gameplayState);

            _gameplayState.Reset();
        }

        public void GoToNextLevel()
        {
            _currentLevel++;
            _newGamePending = false;
            _showTextState.text = $"Новый уровень";
            ChangeState(_showTextState);
        }

        public void GoToGameOver()
        {
            _currentLevel = 0;
            _newGamePending = true;
            _showTextState.text = $"потрачено";
            ChangeState(_showTextState);
        }

        public override ConsoleColor[] CreatePalette()
        {
            return
            [
                ConsoleColor.Red,
                ConsoleColor.Green,
                ConsoleColor.Yellow,
                ConsoleColor.White,
            ];
        }
    }
}
