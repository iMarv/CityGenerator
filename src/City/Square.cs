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
        /// Turns Square into String
        /// </summary>
        /// <returns>Symbol as string</returns>
        public override string ToString() => Symbol.ToString();
    }
}