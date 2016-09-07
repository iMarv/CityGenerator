using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using City.BuildingTypes;
using City;
using City.SquareTypes;

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

        [Fact]
        public void OfficeToStringTest()
        {
            Office a = new Office(1, 1, null);
            Assert.Equal(".", a.ToString());
        }

        [Fact]
        public void PoliceStationToStringTest()
        {
            PoliceStation a = new PoliceStation(1, 1, null);
            Assert.Equal("P", a.ToString());
        }

        [Fact]
        public void SchoolToStringTest()
        {
            School a = new School(1, 1, null);
            Assert.Equal("S", a.ToString());
        }

        [Fact]
        public void ParkToStringTest()
        {
            Park a = new Park(1, 1, null);
            Assert.Equal("*", a.ToString());
        }

        [Fact]
        public void StreetToStringTest()
        {
            Street a = new Street(1, 1, null);
            Assert.Equal("#", a.ToString());
        }
    }
}
