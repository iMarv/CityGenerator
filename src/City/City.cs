using System;
using System.Collections.Generic;
using System.Linq;
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
        public City()
        {
            Height = 50;
            Width = 50;
        }

        /// <summary>
        /// Constructor taking height and width of city
        /// </summary>
        /// <param name="height">Height of the map</param>
        /// <param name="width">Width of the map</param>
        public City(int width, int height)
        {
            Height = height;
            Width = width;
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
            int width = 50;
            int height = 50;

            // (?<width>\d{1,})[x\*](?<height>\d{1,})
            // (?<width>\d{1,})                         Named capture group containing width
            //                 [x\*]                    Seperator, either 'x' or '*'
            //                      (?<height>\d{1,})   Named capture group containing height
            Regex rgxSeperatorString = new Regex(@"(?<width>\d{1,})[x\*](?<height>\d{1,})");
            Match match = rgxSeperatorString.Match(dimensionsSeperator);

            // If match is successful
            if(match.Success)
            {
                // Try to parse results into ints
                int.TryParse(match.Groups["width"].Value, out width);
                int.TryParse(match.Groups["height"].Value, out height);
            }

            // Set height and width
            Width = width;
            Height = height;
        }
    }
}
