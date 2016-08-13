using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.BuildingTypes
{
    class School : Building
    {
        public School(int x, int y, byte rarity) : base('S', x, y, rarity) { }
    }
}
