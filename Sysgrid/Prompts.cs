using Spectre.Console;

namespace Sysgrid
{
    public class Prompts
    {
        public static (int width, int height) GridDetails()
        {
            Console.WriteLine("Create Grid");
            Console.WriteLine("-----------");

            var width = GridLength(forWidth: true);
            var height = GridLength(forWidth: false);

            return (width, height);
        }

        public static int GridLength(bool forWidth)
        {
            var coordinateName = forWidth ? "Width" : "Height";

            return AnsiConsole.Prompt(
                new TextPrompt<int>($"{coordinateName} (5 to 25): ")
                    .PromptStyle("green")
                    .ValidationErrorMessage($"[red]Invalid {coordinateName}[/]")
                    .Validate(i =>
                    {
                        return i switch
                        {
                            < 5 or > 25 => ValidationResult.Error($"[red]{coordinateName} must be within 5 to 25.[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));
        }

        public static OperationType Selection()
        {
            var result = AnsiConsole.Prompt(
                new TextPrompt<int>($"Select operation ({(int)OperationType.Find}: find, {(int)OperationType.Remove}: remove, {(int)OperationType.Exit}: exit): ")
                    .PromptStyle("green")
                    .ValidationErrorMessage("[red]Invalid selection[/]")
                    .Validate(i =>
                    {
                        return i switch
                        {
                            < 1 or > 3 => ValidationResult.Error($"[red]Invalid selection[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));

            return Enum.Parse<OperationType>(result.ToString());
        }

        public static int Coordinate(bool forXCoordinate)
        {
            var coordinateName = forXCoordinate ? "X" : "Y";

            return AnsiConsole.Prompt(
                new TextPrompt<int>($"{coordinateName} Coordinate (1 to 25): ")
                    .PromptStyle("green")
                    .ValidationErrorMessage($"[red]Invalid value[/]")
                    .Validate(i =>
                    {
                        return i switch
                        {
                            < 1 or > 25 => ValidationResult.Error($"[red]Value must be within 0 to 25.[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));
        }
    }
}
