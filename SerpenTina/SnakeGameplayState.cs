using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SerpenTina
{
    internal enum SnakeDir
    {
        Up, Down, Left, Right
    }
    internal class SnakeGameplayState : BaseGameState
    {
        const char _bodySymbol = '■';
        const char _appleSymbol = '\u25CF';

        private struct Cell
        {
            public int _x; public int _y;

            public Cell(int x, int y)
            {
                this._x = x;
                this._y = y;
            }
        }
        public int _fieldWidth { get; set; }
        public int _fieldHeight { get; set; }
        public bool _gameOver { get; private set; }
        public bool _hasWon { get; private set; }
        public int _level { get; set; }


        private List<Cell> _body = new();
        private SnakeDir _currentDir = SnakeDir.Left;
        private float _timeToMove = 0f;
        private Cell _apple = new();
        private Random _random = new();


        public void SetDirection(SnakeDir dir)
        {
            _currentDir = dir;
        }

        public override void Reset()
        {
            _body.Clear();
            var middleY = _fieldHeight / 2;
            var middleX = _fieldWidth / 2;
            _gameOver = false;
            _hasWon = false;
            _currentDir = SnakeDir.Left;
            _body.Add(new(middleX + 3, middleY));
            _apple = new(middleX - 3, middleY);
            _timeToMove = 0f;
        }

        public override void Update(float deltaTime)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            _timeToMove -= deltaTime;
            if (_timeToMove > 0f || _gameOver)
                return;

            _timeToMove = 1f / (4f + _level);
            var head = _body[0];
            var nextCell = ShiftTo(head, _currentDir);
            if (nextCell.Equals(_apple))
            {
                _body.Insert(0, _apple);
                _hasWon = _body.Count >= _level + 3;
                GenerateApple();
                return;
            }
            if (nextCell._x < 0 || nextCell._y < 0 || nextCell._x >= _fieldWidth || nextCell._y >= _fieldHeight)
            {
                _gameOver = true;
                return;
            }
            _body.RemoveAt(_body.Count - 1);
            _body.Insert(0, nextCell);
        }

        private Cell ShiftTo(Cell from, SnakeDir toDir)
        {
            switch (toDir)
            {
                case SnakeDir.Up:
                    return new Cell(from._x, from._y - 1);
                case SnakeDir.Down:
                    return new Cell(from._x, from._y + 1);
                case SnakeDir.Left:
                    return new Cell(from._x - 2, from._y);
                case SnakeDir.Right:
                    return new Cell(from._x + 2, from._y);
            }

            return from;
        }

        public override void Draw(ConsoleRenderer renderer)
        {
            renderer.DrawString($"Уровень: {_level}", 3, 1, ConsoleColor.White);
            renderer.DrawString($"Поглощено яблок: {_body.Count - 1}", 3, 2, ConsoleColor.White);

            foreach (Cell cell in _body)
            {
                renderer.SetPixel(cell._x, cell._y, _bodySymbol, 3);
            }
            renderer.SetPixel(_apple._x, _apple._y, _appleSymbol, 1);
        }
        private void GenerateApple()
        {
            Cell cell;
            cell._x = _random.Next(_fieldWidth);
            if (cell._x % 2 == 0) cell._x++;

            cell._y = _random.Next(_fieldHeight);

            if (_body[0].Equals(cell))
            {
                if (cell._y > _fieldHeight / 2)
                    cell._y--;
                else
                    cell._y++;
            }

            _apple = cell;
        }

        public override bool IsDone()
        {
            return _gameOver || _hasWon;
        }
    }
}
