using System.Collections.Generic;
using Xunit;

namespace CityTests
{
    public class CityTest
    {
        [Fact]
        public void CityConstructorTest0Width()
        {
            int expectedWidth = 31;

            City.City c = new City.City();
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest0Height()
        {
            int expectedHeight = 31;

            City.City c = new City.City();
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void CityConstructorTest1Width()
        {
            int expectedWidth = 31;

            City.City c = new City.City(31, 5);
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest1WidthSanitize()
        {
            int expectedWidth = 3;

            City.City c = new City.City(2, 2);
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest1Height()
        {
            int expectedHeight = 31;

            City.City c = new City.City(4, 31);
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void CityConstructorTest1HeightSanitize()
        {
            int expectedHeight = 31;

            City.City c = new City.City(4, 29);
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void CityConstructorTest2Width()
        {
            int expectedWidth = 31;

            City.City c = new City.City(31);
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest2WidthSanitize()
        {
            int expectedWidth = 3;

            City.City c = new City.City(2);
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest2Height()
        {
            int expectedHeight = 31;

            City.City c = new City.City(31);
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void CityConstructorTest2HeightSanitize()
        {
            int expectedHeight = 31;

            City.City c = new City.City(29);
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void CityConstructorTest3XWidth()
        {
            int expectedWidth = 31;

            City.City c = new City.City("31x5");
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest3XWidthSanitize()
        {
            int expectedWidth = 3;

            City.City c = new City.City("2x5");
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest3XHeight()
        {
            int expectedHeight = 31;

            City.City c = new City.City("4x31");
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void CityConstructorTest3XHeightSanitize()
        {
            int expectedHeight = 31;

            City.City c = new City.City("4x29");
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void CityConstructorTest3StarWidth()
        {
            int expectedWidth = 31;

            City.City c = new City.City("31*5");
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest3StarWidthSanitize()
        {
            int expectedWidth = 3;

            City.City c = new City.City("2*5");
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest3StarHeight()
        {
            int expectedHeight = 31;

            City.City c = new City.City("4*31");
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void CityConstructorTest3StarHeightSanitize()
        {
            int expectedHeight = 31;

            City.City c = new City.City("4*29");
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void GenerateStreetsTest()
        {
            City.City c = new City.City();
            List<string> rows = c.GenerateStreets(15124);
            string result = string.Join("\n", rows);
            Assert.False(true);
        }
    }
}
