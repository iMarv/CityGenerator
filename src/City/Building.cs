using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City
{
    abstract class Building : Square
    {
        private byte _rarity;

        /// <summary>
        /// Gets the rarity of the Building
        /// </summary>
        public byte Rarity
        {
            get { return _rarity; }
            private set { _rarity = value > 100 ? (byte)100 : value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Symbol of the Building</param>
        /// <param name="x">X-Position of the Building</param>
        /// <param name="y">Y-Position of the Building</param>
        /// <param name="rarity">Rarity of the Building</param>
        protected Building(char symbol, int x, int y, byte rarity) : base(symbol, x, y)
        {
            Rarity = rarity;
        }

        public override string ToString() => "O";
    }
}
