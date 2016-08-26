using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City
{
    public class Street : Square
    {
        public Street(int x, int y, City parent) : base('#', x, y, parent) { }
    }
}
