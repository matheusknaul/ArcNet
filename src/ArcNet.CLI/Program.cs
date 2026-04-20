using ArcNet.Core.Entities;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;

var app = new CommandApp();

app.Configure(config =>
{
    config.AddCommand<GreetCommand>("greet");
});

List<string> providers = [
    "Groq - gpt OSS 20B, gpt OSS 120B, Outros;",
    "Local (Ollama) - Personalizado."
];

string topHeader = "[white] Bem vindo ao [SkyBlue2 bold]Arc Net[/] 0.1.0! [/]";

while (true)
{
    AnsiConsole.Clear();

    //var square = new Panel(header)
        //.RoundedBorder();

    //AnsiConsole.Write(square);

    var arcNetAnsi = """
    [DodgerBlue1]
             █████╗ ██████╗  ██████╗     ███╗   ██╗███████╗████████╗
            ██╔══██╗██╔══██╗██╔════╝     ████╗  ██║██╔════╝╚══██╔══╝
            ███████║██████╔╝██║          ██╔██╗ ██║█████╗     ██║   
            ██╔══██║██╔══██╗██║          ██║╚██╗██║██╔══╝     ██║   
            ██║  ██║██║  ██║╚██████╗  ██╗██║ ╚████║███████╗   ██║   
            ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝  ╚═╝╚═╝  ╚═══╝╚══════╝   ╚═╝
    [/]
    """;

    var layout = new Layout()
    .SplitRows(
        new Layout("header"),
        new Layout("specs"),
        new Layout("left"),
        new Layout("right")
    );

    var specs = new Panel(
    new Rows(
        new Markup("[SkyBlue2]Project Name[/]: zeev-automation"),
        new Markup("[SkyBlue2]Provider[/]: Groq"),
        new Markup("[SkyBlue2]Model[/]: gpt oss 120b"),
        new Markup("[SkyBlue2]Api Key[/]: ************key"),
        new Markup("[SkyBlue2]Token Limits[/]: 120k")
    )
    ).RoundedBorder().Expand();

    var useTopLayout = new Layout()
        .SplitRows(
            new Layout("header"),
            new Layout("specs")
        );

    var useViewsLayout = new Layout()
        .SplitColumns(
            new Layout("userPrompt"),
            new Layout("modelView")
        );

    var useViewPromptLayout = new Layout();
    var useViewModelLayout = new Layout()
        .Invisible();

    var useLayout = new Layout()
        .SplitRows(
            useTopLayout,
            useViewPromptLayout
        );

    useTopLayout["header"].Update(
    Align.Center(
        new Panel(arcNetAnsi)
            .Header(topHeader)
            .RoundedBorder()
            .Expand()));
            
    useTopLayout["specs"].Update(specs);

    useViewPromptLayout.Update(
        new Panel("Escolha seu provider abaixo:"));

    AnsiConsole.Write(useLayout);

    AnsiConsole.WriteLine();

    AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Escolha o provider:")
            .AddChoices(providers)
    );

    AnsiConsole.WriteLine();
    
    AnsiConsole.Write(
        new Panel(" ")
        {
            Border = BoxBorder.Rounded,
            BorderStyle = new Style(Color.White),
            Width = 100,
            Padding = new Padding(1, 1, 1, 1)
        }
    );

    var (_, top) = Console.GetCursorPosition();

    // move para início da linha (coluna 2 = dentro da borda)
    Console.SetCursorPosition(2, top - 2);

    // escreve o prompt dentro da box
    Console.Write("> ");

    // agora lê input ali mesmo
    var input = Console.ReadLine();
    
    if (input == "exit")
        break;

    var commandArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    AnsiConsole.Clear();

    try
    {
        app.Run(commandArgs);
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
    }

    AnsiConsole.MarkupLine(""); // espaço antes do próximo loop
}

internal class GreetCommand : Command<GreetCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<name>")]
        [Description("The name to greet")]
        public string Name { get; init; } = string.Empty;
    }

    protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellation)
    {
        System.Console.WriteLine($"Hello, {settings.Name}!");
        return 0;
    }
}