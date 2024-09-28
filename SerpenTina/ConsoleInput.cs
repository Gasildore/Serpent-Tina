using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpenTina
{
    internal class ConsoleInput//a
    {
        public interface IArrowListener//b
        {
            void OnArrowUp();//c
            void OnArrowDown();
            void OnArrowLeft();
            void OnArrowRight();
        }

        private readonly HashSet<IArrowListener> arrowListeners = new();//d

        public void Subscribe(IArrowListener l)//e
        {
            arrowListeners.Add(l);
        }
        public void Update()//f
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        foreach (var l in arrowListeners) l.OnArrowUp();
                        break;
                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        foreach (var l in arrowListeners) l.OnArrowDown();
                        break;
                    case ConsoleKey.LeftArrow or ConsoleKey.A:
                        foreach (var l in arrowListeners) l.OnArrowLeft();
                        break;
                    case ConsoleKey.RightArrow or ConsoleKey.D:
                        foreach (var l in arrowListeners) l.OnArrowRight();
                        break;
                }
            }
        }
    }
}
