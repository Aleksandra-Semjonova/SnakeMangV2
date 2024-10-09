using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMangV2
{
    internal class Figure
    {
        // List, et salvestada joont esindavaid punktiobjekte
        protected List<Point> pList;

        // Horisontaalse joone joonistamise funktioon
        public void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

        internal bool isHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.isHit(p))
                    return true;
            }
            return false;
        }

        private bool isHit(Point point)
        {
            foreach (var p in pList)
            {
                if (p.isHit(point))
                    return true;
            }
            return false;
        }
    }
}
