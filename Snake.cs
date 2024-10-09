using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeMangV2
{

    internal class Snake : Figure
    {
        Direction direction;
        //Loonud uue alaklassi, kus joonistub välja madu
        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        //Madu liigub varem märgitud suunal
        internal void Move()
        {
            Point tail = pList.First(); // First() - tagastab listi esimese elemendi
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        //Tagastab mao pea punkti
        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        // tingimus, kui sõitis vastu saba
        internal bool isHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.isHit(pList[i]))
                    return true;
            }
            return false;
        }

        // sõltuvalt vajutatud tulistajast valib millisesse suunda madu läheb
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                direction = Direction.UP;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                direction = Direction.DOWN;
            }
        }

        // Funktsioon täiendab madude keha söödud toiduga
        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.isHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
