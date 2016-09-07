using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.BuildingTypes
{
    public class Appartment : Building
    {
        public Appartment(int x, int y, City parent) : base('O', x, y, parent) { }
    }
}
