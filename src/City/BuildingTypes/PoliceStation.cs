using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.BuildingTypes
{
    class PoliceStation : Building
    {
        public PoliceStation(int x, int y, byte rarity) : base('P', x, y, rarity) { }
    }
}
