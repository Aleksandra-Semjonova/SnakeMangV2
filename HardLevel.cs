using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMangV2
{

    // kõvatasemeline alamklass
    internal class HardLevel : BaseLevel
    {
        public override string Name => "Kõva";
        public override ConsoleColor Color => ConsoleColor.Red;
        public override int Speed => 50;
        public override int Width => 60;
        public override int Height => 15;
    }
}
