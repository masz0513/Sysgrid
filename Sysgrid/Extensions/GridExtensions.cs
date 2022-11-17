using Spectre.Console;
using Grid = Sysgrid.Core.Grid;

namespace Sysgrid.Extensions
{
    public static class GridExtensions
    {
        /// <summary>
        /// Find and display rectangle details.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void FindRectangleAndDispayDetails(this Grid grid, int x, int y)
        {
            var result = grid.Find(x, y);

            if (result == null)
            {
                AnsiConsole.Markup("[red]No rectangle found based on given coordinate.[/]");
            }
            else
            {
                AnsiConsole.Markup($"[green]Rectangle found - x1: {result.X1 + 1}, y1: {result.Y1 + 1}, x2: {result.X2}, y2: {result.Y2}[/]");
            }

            Console.WriteLine("\n");
        }

        /// <summary>
        /// Remove rectangle and display its details.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void RemoveRectangleAndDisplayDetails(this Grid grid, int x, int y)
        {
            var result = grid.Remove(x, y);

            if (result == null)
            {
                AnsiConsole.Markup("[red]No rectangle found based on given coordinate.[/]");
                Console.WriteLine("\n");
                return;
            }

            AnsiConsole.Markup($"[green]Removed rectangle - x1: {result.X1 + 1}, y1: {result.Y1 + 1}, x2: {result.X2}, y2: {result.Y2}[/]");
            Console.WriteLine();
            grid.ReRender();
        }
    }
}
