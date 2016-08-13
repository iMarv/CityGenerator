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
            string expected = "###############################\nOO#OO#OOO#OOOOO#OOOO#OOO#OOO#OO\nOO#OO#OOO#OOOOO#OOOO#OOO#OOO#OO\n###############################\nOOOOO#OOOOO#OOOO#OOO#OO#OO#OOOO\nOOOOO#OOOOO#OOOO#OOO#OO#OO#OOOO\n###############################\nOOO#OOOOO#OOOO#OO#OOO#OOOO#OO#O\nOOO#OOOOO#OOOO#OO#OOO#OOOO#OO#O\n###############################\nOOOOO#OOOOO#OOOOO#OOOO#OOOO#OOO\nOOOOO#OOOOO#OOOOO#OOOO#OOOO#OOO\n###############################\nOOOO#OOOO#OOOOO#OOO#OO#OOOOO#OO\nOOOO#OOOO#OOOOO#OOO#OO#OOOOO#OO\n###############################\nOO#OOOO#OOOOO#OOOOO#OOO#OOOO#OO\nOO#OOOO#OOOOO#OOOOO#OOO#OOOO#OO\n###############################\nOOOO#OOO#OO#OOOO#OOOOO#OO#OOO#O\nOOOO#OOO#OO#OOOO#OOOOO#OO#OOO#O\n###############################\nOO#OOO#OO#OOO#OO#OOOOO#OOOOO#OO\nOO#OOO#OO#OOO#OO#OOOOO#OOOOO#OO\n###############################\nOOOOO#OO#OO#OOOOO#OOO#OOO#OO#OO\nOOOOO#OO#OO#OOOOO#OOO#OOO#OO#OO\n###############################\nOOO#OO#OOO#OOOO#OOOOO#OO#OOO#OO\nOOO#OO#OOO#OOOO#OOOOO#OO#OOO#OO\n###############################";
            City.City c = new City.City();
            string result = c.GenerateStreets(1);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddSpecialBuildingsTest()
        {
            string expected = "###############################\nXO#LO#XO.#OOOOL#XOOX#.OL#LOL#OX\nLO#XO#XXL#XXZ.L#LOOO#LOO#OOO#OO\n###############################\nOOOLO#LXL.O#XOXX#OLO#XO#.X#OOLO\nOOXXL#OO.OL#LOOO#ZOO#OL#OO#OX..\n###############################\nOOX#XOO.O#OXOX#O.#OOO#XXLO#XX#O\nOOZ#OOLOO#OLO.#OX#OOO#LOXO#XO#X\n###############################\nOLXOO#OOXOO#OOOLO#.OOO#OO.O#.OX\nOO.LO#OOOXO#OOOOX#OOOO#OXXO#LOO\n###############################\n.LOO#OXLO#OOOOO#OOZ#OO#XXOXO#OO\nOXOO#OLXO#XOOOO#LOO#ZO#OOXOX#OO\n###############################\nLO#XOXO#OOOXO#OZO.O#OXO#XOOO#OL\nOO#OOOO#XOOOL#OOXOX#OOO#.OZO#XO\n###############################\nOXXO#XOO#LX#L.XX#O.XOO#OO#OXO#.\nLOXO#OOX#XO#O.OO#L.O.X#O.#X.O#O\n###############################\nOO#OXO#ZZ#LOO#LO#OLOXO#XOOOO#XO\nLL#OOO#XO#XXL#OO#OOOOO#OXXOO#XO\n###############################\n.OOXO#XL#XO#OO.OO#XOO#OOO#OX#OX\nOOLOL#XO#LO#OOOOO#.OO#XOO#OO#O.\n###############################\nOOO#XO#OOX#LOXO#OXOXX#OO#XLO#LO\nO.X#OO#XXL#LXOO#OOOO.#LX#OOL#XX\n###############################";
            City.City c = new City.City();
            string city = c.GenerateStreets(1);
            Dictionary<char, byte> dic = new Dictionary<char, byte>
            {
                { 'X', 25 },
                { 'L', 10 },
                { 'Z', 1 },
                { '.', 7 }
            };

            city = c.AddSpecialBuildings(dic, city, 1);

            Assert.Equal(expected, city);
        }

        [Fact]
        public void AddSpecialBuildingsTestEmptyDictionary()
        {
            string expected = "###############################\nOO#OO#OOO#OOOOO#OOOO#OOO#OOO#OO\nOO#OO#OOO#OOOOO#OOOO#OOO#OOO#OO\n###############################\nOOOOO#OOOOO#OOOO#OOO#OO#OO#OOOO\nOOOOO#OOOOO#OOOO#OOO#OO#OO#OOOO\n###############################\nOOO#OOOOO#OOOO#OO#OOO#OOOO#OO#O\nOOO#OOOOO#OOOO#OO#OOO#OOOO#OO#O\n###############################\nOOOOO#OOOOO#OOOOO#OOOO#OOOO#OOO\nOOOOO#OOOOO#OOOOO#OOOO#OOOO#OOO\n###############################\nOOOO#OOOO#OOOOO#OOO#OO#OOOOO#OO\nOOOO#OOOO#OOOOO#OOO#OO#OOOOO#OO\n###############################\nOO#OOOO#OOOOO#OOOOO#OOO#OOOO#OO\nOO#OOOO#OOOOO#OOOOO#OOO#OOOO#OO\n###############################\nOOOO#OOO#OO#OOOO#OOOOO#OO#OOO#O\nOOOO#OOO#OO#OOOO#OOOOO#OO#OOO#O\n###############################\nOO#OOO#OO#OOO#OO#OOOOO#OOOOO#OO\nOO#OOO#OO#OOO#OO#OOOOO#OOOOO#OO\n###############################\nOOOOO#OO#OO#OOOOO#OOO#OOO#OO#OO\nOOOOO#OO#OO#OOOOO#OOO#OOO#OO#OO\n###############################\nOOO#OO#OOO#OOOO#OOOOO#OO#OOO#OO\nOOO#OO#OOO#OOOO#OOOOO#OO#OOO#OO\n###############################";
            City.City c = new City.City();
            string city = c.GenerateStreets(1);
            Dictionary<char, byte> dic = new Dictionary<char, byte>();

            city = c.AddSpecialBuildings(dic, city, 1);

            Assert.Equal(expected, city);
        }

        [Fact]
        public void AddSpecialBuildingsTestEmptyCity()
        {
            string expected = "###############################\nOXO#OOXOL#OLO#OOOO#OOXOX#LOXO#O\nOXO#OOXOL#OOO#LXOO#OOOOO#OOOX#X\n###############################\nXOOOO#OLOOO#LXOL#OOO#OO#OOL#OO#\nXOOOO#OOLOO#OOLX#OXO#LL#OOX#OO#\n###############################\nXOO#OOOO#LOXX#OOOOX#OXX#OOOOO#X\nLLX#LOOL#OOOO#OOOXL#OOO#XLOOO#L\n###############################\nOOXOO#OOXO#XOXO#OLOX#OOOXO#OOXX\nOOOLX#OXLX#OOOO#XOXO#OOOXO#XOOO\n###############################\nXOOL#OOO#OXOOX#LO#XO#OL#XO#OXO#\nXXXO#OLO#OOOXL#OO#XL#XO#OO#OOO#\n###############################\nOO#XXO#OOOOO#OOOLO#OOLO#OOOLO#L\nOL#OLO#OOOOO#OOOOO#XLOX#OOXLO#O\n###############################\nOOOO#OO#OX#OXO#OOOXO#OOO#OOOOO#\nOOOX#OO#LL#OOO#OXOXX#OOO#OLXOX#\n###############################\nOXO#XO#XL#LX#XO#OX#OO#OXOOO#OOO\nXOO#OL#XO#XO#OX#OX#OL#OOXOO#LOO\n###############################\nOOXXX#OOOOO#OX#OOOO#OOOO#XLOX#O\nOOXOO#OOOOO#XX#XOOO#XOOO#OOXO#O\n###############################\nOXX#LOXOO#OOO#LOO#OLLOX#OOO#OXX\nOOO#OOOOX#XOX#OOO#OOOXO#OOO#OOO\n###############################";
            City.City c = new City.City();
            string city = "";
            Dictionary<char, byte> dic = new Dictionary<char, byte>
            {
                { 'X', 25 },
                { 'L', 10 }
            };

            city = c.AddSpecialBuildings(dic, city, 1);

            Assert.Equal(expected, city);
        }
    }
}
