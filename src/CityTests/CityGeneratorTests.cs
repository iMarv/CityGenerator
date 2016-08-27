using City;
using System.Collections.Generic;
using Xunit;

namespace CityTests
{
    public class CityGeneratorTests
    {
        [Fact]
        public void BuildCityTestInvalidWidth()
        {
            City.City c = CityGenerator.BuildCity(0, 40, 921993);

            Assert.Equal(4, c.Width);
        }

        [Fact]
        public void BuildCityTestInvalidHeight()
        {
            City.City c = CityGenerator.BuildCity(40, 0, 921993);

            Assert.Equal(4, c.Height);
        }

        [Fact]
        public void BuildCityTestInvalidWidthHeight()
        {
            City.City c = CityGenerator.BuildCity(0, 0, 921993);

            Assert.Equal(4, c.Height);
            Assert.Equal(4, c.Width);
        }
        
        [Fact]
        public void BuildCityTestSeed1()
        {
            City.City c = CityGenerator.BuildCity(30, 30, 921993);

            #region expected
            string expected = "##############################\r\nOO#OOOO#.OOO#OOO#OOOO#O.#OO#OO\r\nOO#SOOO#O**O#O*O#OO*O#OO#OO#OO\r\nOO###OO#O**O#P*O##O*O#########\r\nOOOO#OO#O**O#O*SO#.*OO#OO#OO#O\r\nO**O#PO#O*OH#OOOO#OOO.#OO#OO#O\r\nP**O#OO#O*O##OO#####OO########\r\nO**O#OO#O*O#OOO#OOO#OOO#OOO#OO\r\nOO.O#..#OOO#O*O#O*O#OOO#OOO#OO\r\nOO###.O#OO##S*O#O*O##OO#######\r\nOO#OPOO#OO#OO*O#O*OO#.OOO#OOO#\r\nOO#OO.O#OO#O*OO#OOOO#O*OO#OOO#\r\nOO###OO####.*O####OO#.*O##..##\r\nOOOO#OO.O#OO*O#OO#OO#O*O#OOO#S\r\nO**.#O*O.#HOOO#OH#OO#OOO#OO.#O\r\n.**.#.*.##OO###OO#OO##########\r\nO**O#O*O#O..#OOOO#OOO.#OOO#OO#\r\nOOOO#OPO#OOO#OOOO#OOHO#OOO#OO#\r\nOO#######OO##OO###OO####OO####\r\nOO#OOO#OOOO#OOO#.OOO#OS#OOO#OO\r\nOO#OOO#OOSO#OOO#OOOO#OO#.*.#OO\r\nO.#OO####OO#OO####OO####O*O#OO\r\n.O#OO#OO#.O#HO#OO#OHOO#OO*O#OO\r\nOO#O.#OO#OO#HO#OO#OO.O#OOHO#OO\r\nOO####OO####OO#.O#OO#####OO###\r\nOO.O#O.OO#O.OO#OO#OO#OOO#OOO#O\r\nO**O#O**O#OOOO#OO#OO#O*O#OOO#P\r\nO**O#O**O#OO######OO#.*O##OO##\r\nO**O#O**O#OO#OO#OOOO#O*OO#OOO#\r\nOOOO#OOOS#OO#OO#OOOS#O.OO#OO.#\r\n##############################";
            #endregion

            Assert.Equal(expected, c.ToString());
        }

        [Fact]
        public void BuildCityTestSeed2()
        {
            City.City c = CityGenerator.BuildCity(30, 30, 1712016);

            #region expected
            string expected = "##############################\r\nPO#OO#O.O#OO#OO#SOO#O.#OO#OOO.\r\nOO#OO#OOO#HO#OS#.*O#OH#OO#OPPH\r\nOP#OO########OO#O*O#######OO##\r\nOO#OOO.#OO#OSOO#O*OO#OO#OO.O#O\r\nOO#OOOO#OO#OOOO#OOOO#OO#OOOO#O\r\nOO###O.#####OO####OO#OO###OO##\r\nOOOO#OOO#O.#OO#PO#.O#OOOO#OO#.\r\nOOOO#OOO#OO#.O#OO#OO#OO*O#O.#O\r\n.O##########OO#OO#####O*O#####\r\nOO#OOO#OO.#OOO#OOO#OO#O*OO#O.#\r\nOO#.OO#OOO#OOO#.OO#OO#HOOO#.O#\r\nOO#OH##########SO#####.O######\r\nOO#OO#OO#OOO#OOOO#OO#POO#OOO#O\r\nOO#OO#OO#O*O#O**O#OO#OO.#O*O#O\r\nOO#######O*O#O**O#OO##OO#O*O##\r\nOOO#OO.#OO*O#O**O#OOO#OO#O*O#O\r\nOOO#.OO#.OOO#.**O#O*.#OO#O*O#O\r\nOO########OO#O**O#O*O#OO#O*O##\r\n.O#O.#OOO#O.#O**O#O*O#OO#.*OO#\r\nOO#OO#OOO#.O#O*OO#O.O#.O#OO.O#\r\nOS####OO##OO#O*O##OO#####..###\r\nS.OO#...#OOO#O*O#OOO#OO#S.O#OO\r\nO**O#O*O#OOO#OOO#O*O#OO#O*O#OO\r\n.**O#O*.#SO##OO##O*O#O.#O*O###\r\nO**O#S*O#.O#O.O#OO*O#OO#O*O.#O\r\nO*OO#OOO#OO#O*O#H*OO#OO#PO.O#O\r\nO*O##OO##PO#O*O#.*O#######OO##\r\nP*O#OOO#O.S#O*O#O*O#OO#OH#..#O\r\nOOO#OOO#OOO#O.O#OOO#OO#OO#PO#O\r\n##############################";
            #endregion

            Assert.Equal(expected, c.ToString());
        }
        
    }
}
