using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';
        public Wall(int x, int y) : base(x, y)
        {
            InitializeWallBorders();
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.Y);
            SetVerticalLine(0);
            SetVerticalLine(this.X);
        }

        private void SetHorizontalLine(int Y)
        {
            for (int i = 0; i <= this.X; i++)
            {
                this.Draw(i, Y, WallSymbol);
            }
        }
        private void SetVerticalLine(int X)
        {
            for (int i = 0; i <= Y; i++)
            {
                this.Draw(X, i, WallSymbol);
            }
        }
    }
}
