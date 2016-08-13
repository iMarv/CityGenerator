using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.BuildingTypes
{
    class Office : Building
    {
        public Office(int x, int y, byte rarity) : base('.', x, y, rarity) { }
    }
}
