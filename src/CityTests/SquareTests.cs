using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using City.BuildingTypes;
using City;

namespace CityTests
{
    public class SquareTests
    {
        [Fact]
        public void AppartmentToStringTest()
        {
            Appartment a = new Appartment(1, 1, null);
            Assert.Equal("O", a.ToString());
        }

        [Fact]
        public void HospitalToStringTest()
        {
            Hospital a = new Hospital(1, 1, null);
            Assert.Equal("H", a.ToString());
        }
    }
}
