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
        /// Gets the width of the city
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the height of the city
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// List of squares in the city
        /// </summary>
        private readonly List<Square> _squares = new List<Square>();

        /// <summary>
        /// Constructor, sets maximum bounds
        /// </summary>
        /// <param name="width">Width of the City</param>
        /// <param name="height">Height of the City</param>
        public City(int width, int height) : base()
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Add new square to the city
        /// </summary>
        /// <param name="square">Square to add</param>
        public void Add(Square square)
        {
            if (square.X > Width - 1 || square.Y > Height - 1)
            {
                throw new SquareIndexOutOfBoundsException();
            }
            else
            {
                _squares.Add(square);
            }
        }

        public IEnumerator<Square> GetEnumerator() => _squares.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Square>)_squares).GetEnumerator();
        }
    }
}
