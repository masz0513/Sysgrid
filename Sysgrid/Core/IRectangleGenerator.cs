namespace Sysgrid.Core
{
    public interface IRectangleGenerator
    {
        /// <summary>
        /// Generate random number of rectangles
        /// </summary>
        /// <param name="gridWidth"></param>
        /// <param name="gridHeight"></param>
        /// <returns>Rectangles</returns>
        IEnumerable<Rectangle> GenerateRectangles(int gridWidth, int gridHeight);
    }
}
