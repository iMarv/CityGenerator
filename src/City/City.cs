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
        /// Gathers the numbers of empty rows
        /// </summary>
        /// <returns>Numbers of empty rows as array</returns>
        internal int[] getEmptyRowNumbers()
        {
            List<int> result = new List<int>();

            // Iterate through all possible rows defined by height
            for(int row = 0; row < Height; row++)
            {
                // If there are no squares that have a Y-Value for this row
                if(_squares.Where(s => s.Y == row).ToArray().Length == 0)
                {
                    // Add current row to result
                    result.Add(row);
                }
            }

            // Return result as int array
            return result.ToArray<int>();
        }

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
                _squares.Remove(
                    _squares.Where(s => s.X == square.X && s.Y == square.Y).First()
                );
                _squares.Add(square);
            }
        }

        public IEnumerator<Square> GetEnumerator() => _squares.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Square>)_squares).GetEnumerator();
        }

        /// <summary>
        /// Renders city to string
        /// </summary>
        /// <returns>City as string, each square represented by its symbol</returns>
        public override string ToString()
        {
            List<string> result = new List<string>();

            // Iterate through all rows
            for (int row = 0; row < Height; row++)
            {
                result.Add(string.Join("",
                    // Gather all squares in the current row
                    _squares.Where(s => s.Y == row)
                        // Convert them to strings
                        .Select(s => s.ToString())
                            // Turn resulting strings into an array
                            .ToArray<string>()));
            }

            // Join all rows, seperated by a linebreak
            return string.Join(Environment.NewLine, result);
        }
    }
}
