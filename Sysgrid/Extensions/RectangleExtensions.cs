using Sysgrid.Core;

namespace Sysgrid.Extensions
{
    public static class RectangleExtensions
    {
        /// <summary>
        /// Determine if the source rectangle overlaps with the any of the given rectangles.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="rectangles"></param>
        /// <returns>True if overlaps to any rectangles. Otherwise, false.</returns>
        public static bool IsOverlapWithAny(this Rectangle source, IEnumerable<Rectangle> rectangles)
            => rectangles?.Count() > 0 && rectangles.Any(source.IsOverlapWith);

        private static bool IsOverlapWith(this Rectangle source, Rectangle rectangle)
        {
            if (source.IsSameAs(rectangle))
            {
                return true;
            }

            var widthNotAxisAligned = Math.Min(source.X2, rectangle.X2) > Math.Max(source.X1, rectangle.X1);
            var heighNottAxisAligned = Math.Min(source.Y2, rectangle.Y2) > Math.Max(source.Y1, rectangle.Y1);

            return widthNotAxisAligned && heighNottAxisAligned;
        }

        private static bool IsSameAs(this Rectangle source, Rectangle rectangle)
            => source.X1 == rectangle.X1 && source.Y1 == rectangle.Y1 &&
               source.X2 == rectangle.X2 && source.Y2 == rectangle.Y2;
    }
}
