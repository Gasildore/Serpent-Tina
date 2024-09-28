using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpenTina
{
    internal enum SnakeDir
    {
        Up, Down, Left, Right,
    }
    internal class SnakeGameplayState : BaseGameState
    {
        const char _bodySymbol = '\u25CF';
        public int _fieldWidth {  get; set; }
        public int _fieldHeight { get; set; }

        private List<Cell> _body = new();
        private SnakeDir _currentDir = SnakeDir.Left;
        private float _timeToMove = 0f;

        private struct Cell
        {
            public int _x; public int _y;
            public Cell(int x, int y)
            {
                _x = x;
                _y = y;
            }
        }

        public void SetDirection(SnakeDir dir)
        {
            _currentDir = dir;
        }
        private Cell ShiftTo(Cell newCell, SnakeDir toDir)
        {
            switch (toDir)
            {
                case SnakeDir.Up:
                    return new Cell(newCell._x, newCell._y - 1);
                case SnakeDir.Down:
                    return new Cell(newCell._x, newCell._y + 1);
                case SnakeDir.Left:
                    return new Cell(newCell._x - 1, newCell._y);
                case SnakeDir.Right:
                    return new Cell(newCell._x + 1, newCell._y);
            }
            return newCell;
        }

        public override void Reset()
        {
            _body.Clear();
            var middleX = _fieldWidth / 2;
            var middleY = _fieldHeight / 2;
            _currentDir = SnakeDir.Left;
            _body.Add(new(middleX, middleY));
            _timeToMove = 0f;
        }

        public override void Update(float deltaTime)
        {
            _timeToMove -= deltaTime;
            if (_timeToMove > 0f)
                return;
            _timeToMove = 1f / 4;

            var head = _body[0];
            var nextCell = ShiftTo(head, _currentDir);
            _body.RemoveAt(_body.Count - 1);
            _body.Insert(0, nextCell);
        }

        public override void Draw(ConsoleRenderer renderer)
        {
            foreach (Cell cell in _body)
            {
                renderer.SetPixel(cell._x, cell._y, _bodySymbol, 1);
            }            
        }
    }
}
