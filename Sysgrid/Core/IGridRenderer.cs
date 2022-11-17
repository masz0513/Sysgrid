namespace Sysgrid.Core
{
    public interface IGridRenderer
    {
        /// <summary>
        /// Render the rectangles into the grid.
        /// </summary>
        /// <param name="width">Grid Width</param>
        /// <param name="height">Grid Height</param>
        /// <param name="rectangles">Rectangles to render</param>
        public void Render(int width, int height, IEnumerable<Rectangle> rectangles);
    }
}
