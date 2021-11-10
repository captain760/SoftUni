using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Moving_coursor
{
    class Program
    {
        private static int _left=10;
        private static int _top=5;
        private static int _length=3;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            while (true)
            {
                DrawScreen();
                AcceptInput();
            }
        }

        private static void CleanUp()
        {
            while (points.Count() > _length)
            {
                points.Remove(points.First());
            }
        }
        private static bool AcceptInput()
        {

            if (!Console.KeyAvailable)
            {
                return false;
            }
            ConsoleKeyInfo key = Console.ReadKey();
            Position currentPos;
            if (points.Count !=0)
            {
                currentPos = points.Last();
                
            }
            else
            {
                currentPos = GetStartPosition();
            }

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                        _left--;
                    break;
                case ConsoleKey.RightArrow:
                    _left++;
                    break;
                case ConsoleKey.UpArrow:
                    _top--;
                    break;
                case ConsoleKey.DownArrow:
                    _top++;
                    break;

            }
            points.Add(currentPos);
            CleanUp();
            return true;
        }

        private static List<Position> points = new List<Position>();
        private static Position GetStartPosition()
        {
            return new Position()
            {
                left = 0,
                top = 0
            };
        }
        private struct Position
        {
            public int left;
            public int top;
        }
        private static void DrawScreen()
        {
           // Console.Clear();
            foreach (var point in points)
            {
                
            }
            Console.SetCursorPosition(_left, _top);
            Console.Write('*');
        }
    }
}
