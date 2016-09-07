using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.BuildingTypes
{
    public class Hospital : Building
    {
        public Hospital(int x, int y, City parent) : base('H', x, y, parent) { }
    }
}
