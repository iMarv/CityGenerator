using Xunit;

namespace CityTests
{
    public class CityTest
    {
        [Fact]
        public void CityConstructorTest0Width()
        {
            int expectedWidth = 50;

            City.City c = new City.City();
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest0Height()
        {
            int expectedHeight = 50;

            City.City c = new City.City();
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void CityConstructorTest1Width()
        {
            int expectedWidth = 4;

            City.City c = new City.City(4, 5);
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest1Height()
        {
            int expectedHeight = 5;

            City.City c = new City.City(4, 5);
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void CityConstructorTest2Width()
        {
            int expectedWidth = 4;

            City.City c = new City.City(4);
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest2Height()
        {
            int expectedHeight = 4;

            City.City c = new City.City(4);
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void CityConstructorTest3XWidth()
        {
            int expectedWidth = 4;

            City.City c = new City.City("4x5");
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest3XHeight()
        {
            int expectedHeight = 5;

            City.City c = new City.City("4x5");
            Assert.Equal(expectedHeight, c.Height);
        }

        [Fact]
        public void CityConstructorTest3StarWidth()
        {
            int expectedWidth = 4;

            City.City c = new City.City("4*5");
            Assert.Equal(expectedWidth, c.Width);
        }

        [Fact]
        public void CityConstructorTest3StarHeight()
        {
            int expectedHeight = 5;

            City.City c = new City.City("4*5");
            Assert.Equal(expectedHeight, c.Height);
        }
    }
}
