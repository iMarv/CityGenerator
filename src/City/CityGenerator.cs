using City.BuildingTypes;
using City.SquareTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City
{
    public class CityGenerator
    {
        /// <summary>
        /// Default city generation configuration
        /// </summary>
        private static readonly Dictionary<string, int> buildingsDefaultConfig = new Dictionary<string, int>()
        {
            {"Hospital", 10 },
            {"PoliceStation", 10 },
            {"Office", 80 },
            {"School", 15 }
        };

        /// <summary>
        /// Range the random number generator should search for
        /// A small value will allow more rare buildings to spawn
        /// </summary>
        private static readonly int generatorRange = 1000;

        /// <summary>
        /// Generates a city
        /// </summary>
        /// <param name="width">Width of the city</param>
        /// <param name="height">Height of the city</param>
        /// <param name="seed">Seed for city generation</param>
        /// <param name="config">Config for building generation</param>
        /// <returns>Generated city object</returns>
        public static City BuildCity(int width, int height, int seed, Dictionary<string, int> config = null)
        {
            height = sanitizeHeight(height);
            width = width < 4 ? 4 : width;
            Random r = new Random(seed);

            City result = initiateMap(width, height, r);

            return convertBuildings(result, config == null ? buildingsDefaultConfig : config, r);
        }

        /// <summary>
        /// Converts appartments into different builldings using a config and a random number generator
        /// </summary>
        /// <param name="city">City to modify</param>
        /// <param name="config">Config containing generation information</param>
        /// <param name="r">Random number generator</param>
        /// <returns>Modified city</returns>
        private static City convertBuildings(City city, Dictionary<string, int> config, Random r)
        {
            City result = city;
            List<Appartment> convertableAppartments = city.Where(s => s is Appartment).Select(s => (Appartment)s).ToList<Appartment>();
            convertableAppartments.ForEach(a => result.Add(randomBuilding(config, a, r, result)));

            return result;
        }

        /// <summary>
        /// Generates a random building for a position
        /// </summary>
        /// <param name="config">Config containing generation information</param>
        /// <param name="originalAppartment">Appartment that will be replaced</param>
        /// <param name="r">Random number generator</param>
        /// <param name="city">City the building will be placed in</param>
        /// <returns>Random new building object. If random cases to not fullfill any cases, the original appartment is being returned</returns>
        private static Square randomBuilding(Dictionary<string, int> config, Appartment originalAppartment, Random r, City city)
        {
            Building result = null;
            // Iterate through all configElements ordered by their values
            foreach (KeyValuePair<string, int> configElement in config.OrderBy(key => -key.Value))
            {
                if (r.Next(0, generatorRange) <= configElement.Value)
                {
                    result = getBuilding(originalAppartment, configElement.Key, city);
                }
            }

            if (result == null)
                return originalAppartment;
            else
                return result;
        }

        /// <summary>
        /// Creates a new building at the position of another building
        /// </summary>
        /// <param name="originalAppartment">Original appartment that shall be replaced</param>
        /// <param name="key">Key of the new building</param>
        /// <param name="city">City in which the building will be placed</param>
        /// <returns>Building according to key</returns>
        private static Building getBuilding(Appartment originalAppartment, string key, City city)
        {
            int x = originalAppartment.X;
            int y = originalAppartment.Y;
            switch (key)
            {
                case "Hospital":
                    return new Hospital(x, y, city);
                case "Office":
                    return new Office(x, y, city);
                case "PoliceStation":
                    return new PoliceStation(x, y, city);
                case "School":
                    return new School(x, y, city);
                default:
                    return originalAppartment;
            }
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
                // Gather squares which are two squares next to each other
                .Where(s => isRightTile(s) ^ isLeftTile(s))
                // Turn into list
                .ToList<Street>()
                // For every object in the list, add an appartment to the city, overwriting the original streets
                .ForEach(s => result.AddRange(new List<Square>() { new Appartment(s.X, s.Y, result), new Appartment(s.X + (isRightTile(s) ? -1 : 1), s.Y, result) }));
            return addParks(result);
        }

        /// <summary>
        /// Replaces appartments in city that are enclosed by only buildings
        /// </summary>
        /// <param name="city">City to modify</param>
        /// <returns>Modified city</returns>
        private static City addParks(City city)
        {
            City result = city;
            city.Where(s => isSurroundedByBuildings(s) && s is Building).Select(s => (Appartment)s).ToList<Appartment>().ForEach(a => result.Add(new Park(a.X, a.Y, result)));
            return result;
        }

        /// <summary>
        /// Checks if a Square is surrounded by buildings
        /// </summary>
        /// <param name="s">Square to check</param>
        /// <returns>True if surrounden by only buildings, false if not</returns>
        private static bool isSurroundedByBuildings(Square s)
        {
            return s.GetAbove() is Building &&          // N
                s.GetAbove().GetRight() is Building &&  // NO
                s.GetRight() is Building &&             // O
                s.GetRight().GetBelow() is Building &&  // SO
                s.GetBelow() is Building &&             // S
                s.GetBelow().GetLeft() is Building &&   // SW
                s.GetLeft() is Building &&              // W
                s.GetLeft().GetAbove() is Building;
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
        /// <param name="r">Random number generator</param>
        /// <returns>Modified city</returns>
        private static City connectStreets(City city, Random r)
        {
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
        /// Creates a city based on horizontal streets
        /// </summary>
        /// <param name="width">Width of the city</param>
        /// <param name="height">Height of the city</param>
        /// <param name="r">Random number generator</param>
        /// <returns>City consisting of horizontal lines</returns>
        private static City fillHorizontalStreets(int width, int height, Random r)
        {
            City city = new City(width, height);

            // Iterate through all rows of the city
            for (int row = 0; row < height; row++)
            {
                // If this is the first row or the row is divisible by 3 without a rest
                if (row == 0 || row % 3 == 0)
                {
                    // Add a street over the full width of the city
                    for (int column = 0; column < width; column++)
                    {
                        city.Add(new Street(column, row, city));
                    }
                }
            }

            // Return the city
            return connectStreets(city, r);
        }

        /// <summary>
        /// Initiates city creation process
        /// </summary>
        /// <param name="width">Width of the city</param>
        /// <param name="height">Height of the city</param>
        /// <param name="r">Random number generator</param>
        /// <returns>Generated city</returns>
        private static City initiateMap(int width, int height, Random r)
        {
            return fillHorizontalStreets(width, height, r);
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
