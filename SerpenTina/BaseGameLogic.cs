using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpenTina
{
    internal abstract class BaseGameLogic : ConsoleInput.IArrowListener
    {
        protected BaseGameState? _currentState {  get; private set; }
        protected float _time {  get; private set; }
        protected int _screenWidth { get; private set; }
        protected int _screenHeight { get; private set; }
        public abstract void OnArrowUp();
        public abstract void OnArrowDown();
        public abstract void OnArrowLeft();
        public abstract void OnArrowRight();

        public void InitializeInput(ConsoleInput input)
        {
            input.Subscribe(this);
        }

        public abstract void Update(float deltaTime);
        
        protected void ChangeState(BaseGameState? state)
        {
            _currentState?.Reset();
            _currentState = state;
        }

        public void DrawNewState(float deltaTime, ConsoleRenderer renderer)
        {
            _time += deltaTime;

            _screenWidth = renderer._width;
            _screenHeight = renderer._height;

            _currentState?.Update(deltaTime);
            _currentState?.Draw(renderer);

            Update(deltaTime);
        }

        public abstract ConsoleColor[] CreatePalette();
    }
}
