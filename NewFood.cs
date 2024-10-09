using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMangV2
{

    // klass, mis on mõeldud üksikute toidu esindamiseks
    internal class NewFood
    {
        public char Symbol { get; }
        public int Points { get; }

        public NewFood(char symbol, int points)
        {
            Symbol = symbol;
            Points = points;
        }
    }
}
