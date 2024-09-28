using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpenTina
{
    internal abstract class BaseGameLogic : ConsoleInput.IArrowListener//a,b
    {
        public abstract void OnArrowUp();//c
        public abstract void OnArrowDown();
        public abstract void OnArrowLeft();
        public abstract void OnArrowRight();

        public void InitializeInput(ConsoleInput input)//d
        {
            input.Subscribe(this);
        }

        public abstract void Update(float deltaTime);//e
        
    }
}
