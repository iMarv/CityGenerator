using City;
using System.Collections.Generic;
using Xunit;

namespace CityTests
{
    public class CityTest
    {
        [Fact]
        public void CityGeneratorTest()
        {
            City.City c = CityGenerator.BuildCity(40, 40);
            string result = c.ToString();
            Assert.False(true);
        }
    }
}
