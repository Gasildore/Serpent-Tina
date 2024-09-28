using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpenTina
{
    internal class SnakeGameLogic : BaseGameLogic//a,b
    {
        private SnakeGameplayState _gameplayState = new SnakeGameplayState();//d
        public override void Update(float deltaTime)//c
        {
            _gameplayState.Update(deltaTime);//h
        }
        public override void OnArrowUp()//e
        {
            _gameplayState.SetDirection(SnakeDir.Up);
        }
        public override void OnArrowDown()
        {
            _gameplayState.SetDirection(SnakeDir.Down);
        }

        public override void OnArrowLeft()
        {
            _gameplayState.SetDirection(SnakeDir.Left);
        }

        public override void OnArrowRight()
        {
            _gameplayState.SetDirection(SnakeDir.Right);
        }

        public void GoToGameplay()//g
        {
            _gameplayState.Reset();
        }

        
    }
}
