using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.BuildingTypes
{
    class Hospital : Building
    {
        public Hospital(int x, int y, byte rarity) : base('H', x, y, rarity) { }
    }
}
