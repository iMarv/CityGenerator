using City.BuildingTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City
{
    public class CityGenerator
    {
        /// <summary>
        /// Generates a city
        /// </summary>
        /// <param name="width">Width of the map</param>
        /// <param name="height">Height of the map</param>
        /// <param name="seed">Seed for generating, defaults to 14091994</param>
        /// <returns>City object</returns>
        public static City BuildCity(int width, int height, int seed = 14091994)
        {
            height = sanitizeHeight(height);
            width = width < 4 ? 4 : width;

            return initiateMap(width, height, seed);
        }

        /// <summary>
        /// Turns streets between Buildings into appartments
        /// </summary>
        /// <param name="city">City to modify</param>
        /// <returns>Modified city</returns>
        private static City mergeBuildings(City city)
        {
            // Create new object for return
            City result = city;

            // Gather squares that are streets and have building above and below
            city.Where(s => s is Street)
                // Cast these squares into streets
                .Select(s => (Street)s)
                .Where(s => isRightTile(s) ^ isLeftTile(s))
                // Turn into list
                .ToList<Street>()
                // For every object in the list, add an appartment to the city, overwriting the original streets
                .ForEach(s => result.AddRange(new List<Square>() { new Appartment(s.X, s.Y, result), new Appartment(s.X + (isRightTile(s) ? -1 : 1), s.Y, result) }));
            return result;
        }

        /// <summary>
        /// Checks if street has a building above, above-right, below and below-right itself
        /// </summary>
        /// <param name="s">Street to check</param>
        /// <returns>True if yes, false if no</returns>
        private static bool isLeftTile(Street s) => s.GetAbove() is Building && s.GetAbove().GetRight() is Building && s.GetBelow() is Building && s.GetBelow().GetRight() is Building;

        /// <summary>
        /// Checks if street has a building above, above-right, below and below-right itself
        /// </summary>
        /// <param name="s">Street to check</param>
        /// <returns>True if yes, false if no</returns>
        private static bool isRightTile(Street s) => s.GetAbove() is Building && s.GetAbove().GetLeft() is Building && s.GetBelow() is Building && s.GetBelow().GetLeft() is Building;

        /// <summary>
        /// Connects horizontal streets of a city
        /// </summary>
        /// <param name="city">City to connect streets of</param>
        /// <param name="seed">Seed for random</param>
        /// <returns>Modified city</returns>
        private static City connectStreets(City city, int seed)
        {
            Random r = new Random(seed);
            int[] emptyRows = city.getEmptyRowNumbers();

            // Iterate through the array of emptyRows
            for (int i = 0, length = emptyRows.Length; i < length; i += 2)
            {
                // Set original position
                int position = r.Next(2, 5);

                // Iterate through all possible spots in a row
                for (int column = 0, width = city.Width; column < width; column++)
                {
                    // Add an appartment on every possible spot
                    city.Add(new Appartment(column, emptyRows[i], city));
                    city.Add(new Appartment(column, emptyRows[i + 1], city));
                }

                // While the position does not exceed the cities width
                while (position < city.Width)
                {
                    // Add a street at the given position in the current and the next row
                    city.Add(new Street(position, emptyRows[i], city));
                    city.Add(new Street(position, emptyRows[i + 1], city));

                    // Add random amount to position
                    position += r.Next(3, 6);
                }
            }

            return mergeBuildings(city);
        }

        /// <summary>
        /// Creates a city containing horizontal streets
        /// </summary>
        /// <param name="city">City containing streets</param>
        private static City fillHorizontalStreets(int width, int height, int seed)
        {
            City city = new City(width, height);

            // Iterate through all rows of the city
            for (int row = 0; row < height; row++)
            {
                // If this is the first row or the row is divisible by 3 without a rest
                if (row == 0 || row % 3 == 0)
                {
                    // Add a street over the full with of the city
                    for (int column = 0; column < width; column++)
                    {
                        city.Add(new Street(column, row, city));
                    }
                }
            }

            // Return the city
            return connectStreets(city, seed);
        }

        /// <summary>
        /// Initiates city creation process
        /// </summary>
        /// <param name="width">Width of the city</param>
        /// <param name="height">Height of the city</param>
        /// <param name="seed">Seed for generation</param>
        /// <returns>Generated city</returns>
        private static City initiateMap(int width, int height, int seed)
        {
            return fillHorizontalStreets(width, height, seed);
        }

        /// <summary>
        /// Modifies height to fit rendering process
        /// </summary>
        /// <param name="height">Height to modify</param>
        /// <returns>Number decremented by one that is divisble by 3 without rest</returns>
        private static int sanitizeHeight(int height)
        {
            int result = height > 1 ? height : 2;

            while ((result - 1) % 3 > 0)
            {
                result += 1;
            }

            return result;
        }
    }
}
