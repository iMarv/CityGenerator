using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.BuildingTypes
{
    class School : Building
    {
        public School(int x, int y, City parent) : base('S', x, y, parent) { }
    }
}
