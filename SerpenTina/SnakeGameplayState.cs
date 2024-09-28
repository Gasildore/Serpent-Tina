using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpenTina
{
    internal enum SnakeDir//g
    {
        Up, Down, Left, Right,
    }
    internal class SnakeGameplayState : BaseGameState//a,b
    {
        private struct Cell//d
        {
            public int _x; public int _y;
            public Cell(int x, int y)//e
            {
                _x = x;
                _y = y;
            }
        }

        private List<Cell> _body = new();//f
        private SnakeDir _currentDir = SnakeDir.Left;//h
        private float _timeToMove = 0f;//k
        public void SetDirection(SnakeDir dir)//i
        {
            _currentDir = dir;
        }
        private Cell ShiftTo(Cell newCell, SnakeDir toDir)//j
        {
            switch (toDir)
            {
                case SnakeDir.Up:
                    return new Cell(newCell._x, newCell._y + 1);
                case SnakeDir.Down:
                    return new Cell(newCell._x, newCell._y - 1);
                case SnakeDir.Left:
                    return new Cell(newCell._x - 1, newCell._y);
                case SnakeDir.Right:
                    return new Cell(newCell._x + 1, newCell._y);
            }
            return newCell;
        }

        public override void Reset()//c
        {
            _body.Clear();//1
            _currentDir = SnakeDir.Left;//2
            _body.Add(new(0, 0));//3
            _timeToMove = 0f;//4
        }

        public override void Update(float deltaTime)//c
        {
            _timeToMove -= deltaTime;//1
            if (_timeToMove > 0f)//2
                return;
            _timeToMove = 1f / 4;//3

            var head = _body[0];//n
            var nextCell = ShiftTo(head, _currentDir);//o,p
            _body.RemoveAt(_body.Count - 1);//q
            _body.Insert(0, nextCell);//r

            Console.WriteLine($"{_body[0]._x} {_body[0]._y}");//s
        }
    }
}
