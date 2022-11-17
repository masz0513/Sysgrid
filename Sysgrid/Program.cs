using Sysgrid;
using Sysgrid.Core;
using Sysgrid.Extensions;
using Sysgrid.Utils;

/// <summary>
/// Sysgrid
/// A system that track the position of a collection of rectangles on a grid.
/// </summary>

Console.WriteLine("WELCOME TO SYSGRID!");
Console.WriteLine("-------------------");
Console.WriteLine("A system that track the position of a collection of rectangles on a grid.\n");

var (width, height) = Prompts.GridDetails();

var grid = Grid
    .Create(width, height)
    .PlaceRectangles(new RectangleGenerator())
    .Render(new ConsoleGridRenderer());

OperationType selection;

do
{
    selection = Prompts.Selection();

    if (selection == OperationType.Exit)
    {
        break;
    }

    var x = Prompts.Coordinate(forXCoordinate: true) - 1;
    var y = Prompts.Coordinate(forXCoordinate: false) - 1;

    if (selection == OperationType.Find)
    {
        grid.FindRectangleAndDispayDetails(x, y);
    }

    if (selection == OperationType.Remove)
    {
        grid.RemoveRectangleAndDisplayDetails(x, y);
    }
} while (true);