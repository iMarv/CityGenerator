using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City
{
    class Street : Square
    {
        public Street(int x, int y) : base('#', x, y) { }
    }
}
