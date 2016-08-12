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
            string expected = "###############################\nXX#OO#OOO#OLX.L#OXXO#OOO#OOO#LO\nOX#XO#OXO#OOZ.O#LO.O#OLX#OOO#XO\n###############################\nOOOOO#OOOOX#OOXL#.OO#OL#XO#LXOO\nOXXXL#XOOOO#.OOX#ZX.#LX#OO#O.LO\n###############################\nOXO#LLOXO#OO.O#XO#OOO#XLXO#XO#O\nOXZ#XO..O#.OOO#XX#OOL#LOL.#XX#L\n###############################\nOOOOO#.OOOL#OOXXL#XXXL#O.XX#OOO\nOXOOO#XOXL.#OXX.O#OXXO#XXOO#XOL\n###############################\nOOOL#OXOO#XOOOO#OOZ#OO#O.OOO#OO\nXOLO#OXOO#OO.OL#OOO#Z.#OLO.O#OO\n###############################\nOO#OXOO#LOXXO#OZLOX#OL.#OXX.#XX\nOO#XX.O#OO.OO#OOOOO#XLO#XOZL#OO\n###############################\nXOL.#OLO#LX#LOOO#XOOOO#XO#OXL#O\nOOXO#LOO#XX#XOX.#XOOOO#XO#XOX#X\n###############################\nXX#.OO#ZZ#XOO#XO#OX..O#OXLLX#OO\nXO#XXO#OX#OOL#OO#XOOOO#XOLLO#XX\n###############################\nOOOOO#OO#XX#OOOXO#XXL#OOO#OO#OO\nOOL.O#OO#XX#LOXXO#OOO#OXX#OO#OO\n###############################\nXOO#OO#OOX#OLOX#XOOOX#XX#.XO#OX\n.OO#OX#OOO#OOXO#XOOOO#OO#LOX#OO\n###############################";
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
            string expected = "###############################\nXXO#OOOOO#LXL#OXXO#OOOOO#OLOO#X\nXOO#XOOOO#LOO#OLXO#OOXOO#OOOO#O\n###############################\nOOOXO#OXLOO#OLXO#LXO#OO#XXX#LX#\nOOOOO#OXXLX#OOOL#OOX#OL#LOX#OO#\n###############################\nOOX#OOOO#XLXO#XOOOX#XOO#OOOXX#O\nOLL#OLXX#LOOO#OOOOO#LOO#XXLXX#X\n###############################\nLOXXO#OOOX#OOOX#OXLO#XXOOX#XOXX\nOOXOL#OOOL#OXOO#XOOO#OOOOO#OOOO\n###############################\nOOXO#LOO#XOOOO#OL#OO#OO#LO#OOO#\nOOOX#OOL#OXXOO#LO#XO#LO#XX#XXO#\n###############################\nOX#XOO#OOOOO#OOOXL#OXOL#OOXOL#O\nLO#LXL#OOOXO#OOOXO#OXLO#OOXOL#O\n###############################\nOXXX#OX#XO#OOO#XOXOX#XXX#OOXOO#\nXOOX#OO#XL#LXO#OXOXX#OOX#OOLOO#\n###############################\nXOO#OO#XO#LL#OX#XO#OO#OOOOX#XOO\nOXO#XX#LO#OO#OO#OO#OO#LOOOX#XLO\n###############################\nXXOOO#OOXXO#OO#OXOO#OOOO#XOLO#X\nXOOOX#XXXOO#XO#OOXO#OOOO#XOXO#O\n###############################\nOOO#OLOXO#OXO#XLX#OOLLO#XOO#OXO\nOXO#OOOOO#XOO#OOX#XXOXO#XXO#OOO\n###############################";
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
