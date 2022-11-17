namespace Sysgrid.Core
{
    public class Rectangle
    {
        public int X1 { get; init; }

        public int Y1 { get; init; }

        public int X2 { get; init; }

        public int Y2 { get; init; }

        public string Color { get; set; } = "white";

        public IEnumerable<(int x, int y)> DataPoints { get; init; }

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;

            DataPoints = GetDataPoints();
        }

        private IEnumerable<(int x, int y)> GetDataPoints()
        {
            for(int x = X1; x < X2; x++)
            {
                for(int y = Y1; y < Y2; y++)
                {
                    yield return (x, y);
                }
            }
        }
    }
}
