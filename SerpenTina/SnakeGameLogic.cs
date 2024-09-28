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
        public override void Update(float deltaTime)
        {
            if (_currentState != _gameplayState)
                GoToGameplay();
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
            _gameplayState._fieldWidth = _screenWidth;
            _gameplayState._fieldHeight = _screenHeight;
            ChangeState(_gameplayState);

            _gameplayState.Reset();
        }

        public override ConsoleColor[] CreatePalette()
        {
            return
            [
                ConsoleColor.Red,
                ConsoleColor.Green,
                ConsoleColor.Blue,
                ConsoleColor.White,
            ];
        }
    }
}
