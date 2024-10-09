using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMangV2
{
    internal class Point
    {
        // Kuulutame välja klassimuutujad
        public int x;
        public int y;
        public char sym;

        public Point() { }

        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        //Liigub madu määratud suunas etteantud offsetiga.
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if (direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset;
            }
            else if (direction == Direction.DOWN)
            {
                y = y + offset;
            }
        }

        public bool isHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }

        // Funktsioon joonistussümboli kindlal positsioonil
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(sym);
        }

        // Puhastab saba punkti kus ta oli
        public void Clear()
        {
            sym = ' ';
            Draw();
        }
    }
}
