using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{

    /// <summary>
    /// contains Various functions responsible for handling conversions ....
    /// </summary>
    class Util
    {
        /// <summary>
        ///  converts and integer containing Red Green Blue color combination into three sperated integers
        ///   using bit manipulation 
        /// </summary>

        public static  RGBPixel GetRGBPixel(int rgb)
        {
            RGBPixel RGB = new RGBPixel();
            RGB.blue = Convert.ToByte(rgb & 255);
            RGB.green = Convert.ToByte((rgb >> 8) & 255);
            RGB.red = Convert.ToByte((rgb >> 16) & 255);
            return RGB;
        }

        /// <summary>
        /// returns an integer Combining the three main colors red,green,blue using bit manipulation 
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <returns></returns>
        
        public static int GetRGBInteger(int red, int green, int blue)
        {
            return (red << 16) + (green << 8) + (blue);
        }
        public static int CalculateDistanceFromWhiteColor(int rgb)
        {
            int blue = rgb & 255;
            int green = (rgb >> 8) & 255;
            int red = (rgb >> 16) & 255;
            int white = 255;
            return (white - red) * (white - red) + (white - green) * (white - green) + (white - blue) * (white - blue);
        }
        public static  double CalculateEdgeValue(int currentNode, int otherNode)
        {
            RGBPixel rgb1 = Util.GetRGBPixel(ImageQuantizer.distinctColors[currentNode]);
            RGBPixel rgb2 = Util.GetRGBPixel(ImageQuantizer.distinctColors[otherNode]);
            return Math.Sqrt( (rgb1.red - rgb2.red) * (rgb1.red - rgb2.red) +
                   (rgb1.green - rgb2.green) * (rgb1.green - rgb2.green) +
                   (rgb1.blue - rgb2.blue) * (rgb1.blue - rgb2.blue));
        }
    }
}
