using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpenTina
{
    internal abstract class BaseGameState//a
    {
        public abstract void Update(float deltaTime);//b
        public abstract void Reset();//c
    }    
}
