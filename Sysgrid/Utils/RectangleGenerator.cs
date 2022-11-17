﻿using Sysgrid.Core;
using Sysgrid.Extensions;

namespace Sysgrid.Utils
{
    public class RectangleGenerator : IRectangleGenerator
    {
        private readonly string[] Colors = new[] { "maroon", "green", "olive", "navy", "purple", "teal", "silver", "grey", "red", "lime", "yellow", "blue", "fuchsia", "aqua" };
        private const int MinLength = 2;

        /// <inheritdoc />
        public IEnumerable<Rectangle> GenerateRectangles(int gridWidth, int gridHeight)
        {
            // Note: The ff. implementation is for simplicity sake. There are various ways to make it better.

            var rectangles = new List<Rectangle>();

            var maxRectWidth = (int)(gridWidth * 0.7);
            var maxRectHeight = (int)(gridHeight * 0.7);

            var maxX1 = gridWidth - 2;
            var maxY1 = gridHeight - 2;

            var random = new Random();
            var overlapCount = 0;
            var maxOverlap = (gridWidth * gridHeight) / (gridWidth + gridHeight);
            maxOverlap = maxOverlap <= 10 ? 10 : maxOverlap;

            var colorIdx = 0;

            do
            {
                var x1 = random.Next(0, maxX1 + 1);
                var y1 = random.Next(0, maxY1 + 1);

                var x2 = x1 + MinLength >= maxRectWidth
                    ? x1 + MinLength
                    : random.Next(x1 + MinLength, x1 + maxRectWidth);

                var y2 = y1 + MinLength >= maxRectHeight
                    ? y1 + MinLength
                    : random.Next(y1 + MinLength, y1 + maxRectHeight);

                if(x1 == x2 || y1 == y2 || x1 > x2 || y1 > y2)
                {
                    continue;
                }

                var rectangle = new Rectangle(x1, y1, x2, y2);
                
                if (rectangle.IsOverlapWithAny(rectangles))
                {
                    overlapCount += 1;
                }
                else
                {
                    rectangle.Color = Colors[colorIdx];
                    colorIdx += 1;
                    colorIdx %= Colors.Length;

                    rectangles.Add(rectangle);
                }
            } while (overlapCount <= maxOverlap || rectangles.Count() < 2);

            return rectangles;
        }
    }
}
