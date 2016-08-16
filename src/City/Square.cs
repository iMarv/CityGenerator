namespace City
{
    public abstract class Square
    {
        /// <summary>
        /// Get the Symbol of the Square
        /// </summary>
        public char Symbol { get; }

        /// <summary>
        /// Get the X-Position of the Square
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Get the Y-Position of the Square
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// City this square is contained in
        /// </summary>
        private City _parentCity;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Symbol of the Square</param>
        /// <param name="x">X-Position of the Square</param>
        /// <param name="y">Y-Position of the Square</param>
        protected Square(char symbol, int x, int y, City parent)
        {
            Symbol = symbol;
            X = x;
            Y = y;
            _parentCity = parent;
        }

        /// <summary>
        /// Gets the Square above the current one
        /// </summary>
        /// <param name="distance">Distance of the desired square, defaults to 1</param>
        /// <returns>Square above the current square with a given distance</returns>
        public Square GetAbove(int distance = 1) => _parentCity.GetAtPosition(X, Y + distance);

        /// <summary>
        /// Gets the Square below the current one
        /// </summary>
        /// <param name="distance">Distance of the desired square, defaults to 1</param>
        /// <returns>Square below the current square with a given distance</returns>
        public Square GetBelow(int distance = 1) => _parentCity.GetAtPosition(X, Y - distance);

        /// <summary>
        /// Gets the Square to the left of the current one
        /// </summary>
        /// <param name="distance">Distance of the desired square, defaults to 1</param>
        /// <returns>Square to the left of the current square with a given distance</returns>
        public Square GetLeft(int distance = 1) => _parentCity.GetAtPosition(X - distance, Y);

        /// <summary>
        /// Gets the Square to the right of the current one
        /// </summary>
        /// <param name="distance">Distance of the desired square, defaults to 1</param>
        /// <returns>Square to the left of the current square with a given distance</returns>
        public Square GetRight(int distance = 1) => _parentCity.GetAtPosition(X + distance, Y);

        /// <summary>
        /// Turns Square into String
        /// </summary>
        /// <returns>Symbol as string</returns>
        public override string ToString() => Symbol.ToString();
    }
}