using Spectre.Console;
using Sysgrid.Core;

namespace Sysgrid.Utils
{
    public class ConsoleGridRenderer : IGridRenderer
    {
        /// <inheritdoc />
        public void Render(int width, int height, IEnumerable<Rectangle> rectangles)
        {
            Console.WriteLine();

            DisplayRectangleDetails(rectangles);

            var table = new Table();
            table.Border(TableBorder.Rounded);

            BuildHeaders(table, width);
            AddRows(table, rectangles, width, height);

            AnsiConsole.Write(table);
        }

        private static void AddRows(Table table, IEnumerable<Rectangle> rectangles, int width, int height)
        {
            var dataPoints = GetAllDataPoints(rectangles);

            for (int y = 0; y < height; y++)
            {
                var columns = new List<string> { $"{y + 1}" };

                for (int x = 0; x < width; x++)
                {
                    var coordinate = dataPoints.FirstOrDefault(c => c.x == x && c.y == y);
                    var text = string.IsNullOrEmpty(coordinate.color)
                        ? "-"
                        : $"[{coordinate.color}]■[/]";
                    columns.Add(text);
                }

                table.AddRow(columns.ToArray());
            }
        }

        private static void DisplayRectangleDetails(IEnumerable<Rectangle> rectangles)
        {
            Console.WriteLine("Rectangles");

            for (int i = 0; i < rectangles.Count(); i++)
            {
                var rect = rectangles.ElementAt(i);

                Console.WriteLine($"{i+1}. x1: {rect.X1 + 1}, y1: {rect.Y1 + 1}, x2: {rect.X2}, y2: {rect.Y2}");
            }
        }

        private static IEnumerable<(int x, int y, string color)> GetAllDataPoints(IEnumerable<Rectangle> rectangles)
            => rectangles.SelectMany(r => r.DataPoints.Select(c => (c.x, c.y, r.Color)));

        private static void BuildHeaders(Table table, int width)
        {
            for (int i = 0; i <= width; i++)
            {
                table.AddColumn(new TableColumn(i == 0 ? "XY" : $"{i}")
                {
                    Alignment = Justify.Center
                });
            }
        }
    }
}
