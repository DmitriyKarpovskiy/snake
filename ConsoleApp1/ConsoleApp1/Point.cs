using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
        struct Point
        {
            public int x { get; set; }
            public int y { get; set; }
            public char ch { get; set; }

            public static bool operator ==(Point a, Point b) =>
                 (a.x == b.x && a.y == b.y) ? true : false;
            public static bool operator !=(Point a, Point b) =>
                (a.x != b.x || a.y != b.y) ? true : false;

             public static implicit operator Point((int, int, char) value) =>
                new Point { x = value.Item1, y = value.Item2, ch = value.Item3 };

             private void DrawPoint(char ch)
             {
                Console.SetCursorPosition(x, y);
                Console.Write(ch);
             }

             public void Draw()
             {
                DrawPoint(ch);
             }

             public void Clear()
             {
                DrawPoint(' ');
             }
        }
    }
