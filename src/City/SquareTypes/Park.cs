using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.SquareTypes
{
    public class Park : Square
    {
        public Park(int x, int y, City parent) : base('*', x, y, parent) { }
    }
}
