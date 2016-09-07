using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City
{
    public abstract class Building : Square
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Symbol of the Building</param>
        /// <param name="x">X-Position of the Building</param>
        /// <param name="y">Y-Position of the Building</param>
        /// <param name="rarity">Rarity of the Building</param>
        protected Building(char symbol, int x, int y, City parent) : base(symbol, x, y, parent)
        { }
    }
}
