using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        protected Food(int x, int y) : base(x, y)
        {
        }
         
    }
}
