using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.BuildingTypes
{
    public class Office : Building
    {
        public Office(int x, int y, City parent) : base('.', x, y, parent) { }
    }
}
