﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace City
{
    public class City
    {
        public int Height { get; set; }
        public int Width { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public City() : this(31)
        { }

        /// <summary>
        /// Constructor taking height and width of city
        /// </summary>
        /// <param name="height">Height of the map</param>
        /// <param name="width">Width of the map</param>
        public City(int width, int height)
        {
            sanitizeDimensions(width, height, out width, out height);
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Constructor taking only one parameter which translates to width and height
        /// </summary>
        /// <param name="dimensions">Parameter defining width and height</param>
        public City(int dimensions) : this(dimensions, dimensions)
        { }

        /// <summary>
        /// Constructor taking string containing seperator. Supports '*' and 'x' as seperator. Example string: "22x23" or "12*90"
        /// </summary>
        /// <param name="dimensionsSeperator">String containing dimensions and seperator</param>
        public City(string dimensionsSeperator)
        {
            // Set default values
            int width = 31;
            int height = 30;

            // (?<width>\d{1,})[x\*](?<height>\d{1,})
            // (?<width>\d{1,})                         Named capture group containing width
            //                 [x\*]                    Seperator, either 'x' or '*'
            //                      (?<height>\d{1,})   Named capture group containing height
            Regex rgxSeperatorString = new Regex(@"(?<width>\d{1,})[x\*](?<height>\d{1,})");
            Match match = rgxSeperatorString.Match(dimensionsSeperator);

            // If match is successful
            if (match.Success)
            {
                // Try to parse results into ints
                int.TryParse(match.Groups["width"].Value, out width);
                int.TryParse(match.Groups["height"].Value, out height);
            }

            sanitizeDimensions(width, height, out width, out height);

            // Set height and width
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Generates a streetmap for a city
        /// </summary>
        /// <param name="seed">Seed for generation</param>
        /// <returns>List of strings containing rows of a city</returns>
        public List<string> GenerateStreets(int seed)
        {
            List<string> result = new List<string>();
            // Iterate through all rows
            for(int row = 0, rows = Height; row < rows; row++)
            {
                // If it is the first row or the row is divideable by 3
                if(row == 0 || row % 3 == 0)
                {
                    // Add street to result
                    result.Add(new string('#', Width));

                    // If this is not the last row
                    if (row + 1 < rows)
                    {
                        // Create a building row
                        StringBuilder buildings = new StringBuilder(new string('O', Width));

                        // create a random generator with seed and row
                        Random random = new Random(seed + row);

                        // Iterate through row while the position is still contained in the width
                        for(int position = random.Next(2, 6); position < Width; position += random.Next(3, 7))
                        {
                            // Add a street a given position
                            buildings[position] = '#';
                        }
                        
                        // Add two buildingrows
                        result.AddRange(new List<string>() { buildings.ToString(), buildings.ToString() });
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Fixes the dimensions to fit the rendering process
        /// </summary>
        /// <param name="width">Given width</param>
        /// <param name="height">Given height</param>
        private void sanitizeDimensions(int width, int height, out int oWidth, out int oHeight)
        {
            // If width is too low, set default value
            if (width < 3)
            {
                width = 3;
            }

            // If height is too low, set default value
            if(height < 7)
            {
                height = 7;
            }

            // Add to height until it fits to map generation process
            while (((height - 1) % 3) > 0)
            {
                height++;
            }

            oWidth = width;
            oHeight = height;
        }
    }
}
