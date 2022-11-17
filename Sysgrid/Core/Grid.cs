namespace Sysgrid.Core
{
    public class Grid
    {
        public int Width { get; init; }
        public int Height { get; init; }

        public IList<Rectangle> Rectangles { get; private set; } = Array.Empty<Rectangle>();

        private IGridRenderer? _renderer;

        private Grid(int width, int height)
        {
            if(!IsValidLength(width) || !IsValidLength(height))
            {
                throw new ArgumentException("Width and height must be within 5 to 25.");
            }

            Width = width;
            Height = height;
        }

        public static Grid Create(int width, int height)
            => new(width, height);

        private static bool IsValidLength(int value) => value >= 5 && value <= 25;

        /// <summary>
        /// Place random number of rectangles to the grid.
        /// </summary>
        /// <returns>Grid Instance</returns>
        public Grid PlaceRectangles(IRectangleGenerator generator)
        {
            Rectangles = generator.GenerateRectangles(Width, Height).ToList();
            return this;
        }

        /// <summary>
        /// Display Grid
        /// </summary>
        /// <param name="displayProvider">Display provider</param>
        /// <returns>Grid Instance</returns>
        public Grid Render(IGridRenderer renderer)
        {
            _renderer = renderer;
            _renderer.Render(Width, Height, Rectangles);
            return this;
        }

        /// <summary>
        /// Display Grid
        /// </summary>
        /// <param name="displayProvider">Display provider</param>
        /// <returns>Grid Instance</returns>
        public void ReRender()
        {
            _renderer?.Render(Width, Height, Rectangles);
        }

        /// <summary>
        /// Find a rectangle based on a given position.
        /// </summary>
        /// <param name="x">X Coordinate</param>
        /// <param name="y">Y Coordinate</param>
        /// <returns>Rectangle details if found. Otherwise, null.</returns>
        public Rectangle? Find(int x, int y)
            => Rectangles.FirstOrDefault(r => r.DataPoints.Any(c => c.x == x && c.y == y));

        /// <summary>
        /// Remove a rectangle from the grid based on given position.
        /// </summary>
        /// <param name="x">X Coordinate</param>
        /// <param name="y">Y Coordinate</param>
        /// <returns>Details of the removed rectangle. Otherwise, null if not found.</returns>
        public Rectangle? Remove(int x, int y)
        {
            var rectangle = Find(x, y);
            
            if(rectangle != null)
            {
                Rectangles.Remove(rectangle);
            }

            return rectangle;
        }
    }
}