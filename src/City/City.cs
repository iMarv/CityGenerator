using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace City
{
    public class City : IEnumerable<Square>
    {
        /// <summary>
        /// List of squares in the city
        /// </summary>
        private readonly List<Square> _squares = new List<Square>();

        /// <summary>
        /// Add new square to the city
        /// </summary>
        /// <param name="square">Square to add</param>
        public void Add(Square square)
        {
            _squares.Add(square);
        }

        public IEnumerator<Square> GetEnumerator() => _squares.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Square>)_squares).GetEnumerator();
        }
    }
}
