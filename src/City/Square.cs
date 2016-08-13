namespace City
{
    abstract class Square
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
        /// Constructor
        /// </summary>
        /// <param name="symbol">Symbol of the Square</param>
        /// <param name="x">X-Position of the Square</param>
        /// <param name="y">Y-Position of the Square</param>
        protected Square(char symbol, int x, int y)
        {
            Symbol = symbol;
            X = x;
            Y = y;
        }

        /// <summary>
        /// Turns Square into String
        /// </summary>
        /// <returns>Symbol as string</returns>
        public override string ToString() => Symbol.ToString();
    }
}