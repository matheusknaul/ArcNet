using ArcNet.CLI.Renderers.Abstractions;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace ArcNet.CLI.Renderers;

public sealed class ConsoleAppRenderer : IRenderer<ConsoleAppState>
{
    public void Render(ConsoleAppState model)
    {
        AnsiConsole.Clear();

        var layout = new Layout("Root")
            .SplitRows(
                new Layout("Header").Size(7),
                new Layout("Body"),
                new Layout("Footer").Size(3));

        layout["Body"].SplitColumns(
            new Layout("History").Ratio(2),
            new Layout("Context").Ratio(1));

        layout["Header"].Update(BuildHeader(model));
        layout["History"].Update(model.HasConversation ? BuildHistory(model) : BuildWelcome(model));
        layout["Context"].Update(BuildContext(model));
        layout["Footer"].Update(BuildFooter(model));

        AnsiConsole.Write(layout);
    }

    private static IRenderable BuildHeader(ConsoleAppState state)
    {
        var grid = new Grid()
            .AddColumn(new GridColumn().NoWrap())
            .AddColumn();

        grid.AddRow(
            new Markup(GetLogoMarkup()),
            new Markup(
                $"[bold white]ArcNet[/] [grey]developer console for .NET[/]\n" +
                $"[grey]Project[/] [white]{Markup.Escape(state.ProjectName)}[/]    " +
                $"[grey]Provider[/] [white]{Markup.Escape(state.ProviderName)}[/]\n" +
                $"[grey]Model[/] [white]{Markup.Escape(state.ModelName)}[/]    " +
                $"[grey]Status[/] {GetStatusMarkup(state.Status)}\n" +
                "[grey]Ask naturally, or use /help for commands.[/]"));

        return new Padder(grid, new Padding(2, 0, 2, 0));
    }

    private static Panel BuildHistory(ConsoleAppState state)
    {
        if (state.History.Count == 0)
        {
            return new Panel("[grey]Historico vazio. Digite /help para comecar.[/]")
                .Header("Conversa")
                .Border(BoxBorder.Rounded);
        }

        var table = new Table()
            .NoBorder()
            .Expand()
            .AddColumn(new TableColumn("[grey]Hora[/]").NoWrap())
            .AddColumn(new TableColumn("[grey]Origem[/]").NoWrap())
            .AddColumn(new TableColumn("[grey]Mensagem[/]"));

        foreach (var item in state.History)
        {
            table.AddRow(
                $"[grey]{item.CreatedAt:HH:mm:ss}[/]",
                GetRoleMarkup(item.Role),
                Markup.Escape(item.Content));
        }

        return new Panel(table)
            .Header("Conversa")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Grey);
    }

    private static Panel BuildWelcome(ConsoleAppState state)
    {
        var columns = new Grid()
            .AddColumn()
            .AddColumn();

        columns.AddRow(BuildWelcomeLeft(state), BuildWelcomeRight(state));

        return new Panel(columns)
            .Header("[bold cyan]Welcome[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Cyan1)
            .Padding(1, 0);
    }

    private static IRenderable BuildWelcomeLeft(ConsoleAppState state)
    {
        var rows = new Rows(
            new Markup("[bold white]Bem-vindo de volta.[/]"),
            new Text(""),
            new Markup("[grey]ArcNet esta preparando um fluxo de agente focado em solucoes .NET.[/]"),
            new Text(""),
            new Markup($"[grey]Workspace[/]\n[white]{Markup.Escape(GetShortPath(Environment.CurrentDirectory))}[/]"));

        return new Padder(rows, new Padding(1, 1));
    }

    private static IRenderable BuildWelcomeRight(ConsoleAppState state)
    {
        var table = new Table()
            .NoBorder()
            .Expand()
            .AddColumn(new TableColumn("[bold cyan]Recent Activity[/]"))
            .AddColumn(new TableColumn("[bold cyan]Next[/]"));

        IEnumerable<string> activity = state.ActivityLines.Count == 0
            ? new[] { "Build status ready", "Project context loaded", "Console UI online" }
            : state.ActivityLines;

        IEnumerable<string> hints = state.HintLines.Count == 0
            ? new[] { "/help for commands", "/status for state", "Type a request to plan" }
            : state.HintLines;

        var activityRows = activity.ToArray();
        var hintRows = hints.ToArray();
        var rows = Math.Max(activityRows.Length, hintRows.Length);
        for (var index = 0; index < rows; index++)
        {
            table.AddRow(
                index < activityRows.Length ? Markup.Escape(activityRows[index]) : "",
                index < hintRows.Length ? Markup.Escape(hintRows[index]) : "");
        }

        return table;
    }

    private static Panel BuildContext(ConsoleAppState state)
    {
        IEnumerable<string> rows = state.ContextLines.Count == 0
            ? new[] { "Contexto ainda nao carregado." }
            : state.ContextLines;

        var table = new Table()
            .NoBorder()
            .Expand()
            .AddColumn("[grey]Contexto[/]");

        foreach (var row in rows)
            table.AddRow(Markup.Escape(row));

        return new Panel(table)
            .Header("Projeto")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Grey);
    }

    private static IRenderable BuildFooter(ConsoleAppState state)
    {
        return new Rows(
            new Rule().RuleStyle("grey"),
            new Markup("[grey]> Type a request, or try[/] [cyan]/help[/] [grey]-[/] [cyan]/context[/] [grey]-[/] [cyan]/models[/] [grey]-[/] [cyan]/exit[/]"));
    }

    private static string GetRoleMarkup(string role)
    {
        return role switch
        {
            "Voce" => "[bold deepskyblue1]Voce[/]",
            "ArcNet" => "[bold cyan]ArcNet[/]",
            "Sistema" => "[bold yellow]Sistema[/]",
            _ => Markup.Escape(role)
        };
    }

    private static string GetStatusMarkup(ConsoleAgentStatus status)
    {
        return status switch
        {
            ConsoleAgentStatus.Idle => "[grey]Idle[/]",
            ConsoleAgentStatus.Planning => "[yellow]Planning[/]",
            ConsoleAgentStatus.Executing => "[blue]Executing[/]",
            ConsoleAgentStatus.Done => "[green]Done[/]",
            ConsoleAgentStatus.Error => "[red]Error[/]",
            _ => "[grey]Unknown[/]"
        };
    }

    private static string GetLogoMarkup()
    {
        return """
[cyan]   _             _   _      _   
  / \   _ __ ___| \ | | ___| |_ 
 / _ \ | '__/ __|  \| |/ _ \ __|
/ ___ \| | | (__| |\  |  __/ |_ 
/_/   \_\_|  \___|_| \_|\___|\__|[/]
""";
    }

    private static string GetShortPath(string path)
    {
        const int maxLength = 58;

        if (path.Length <= maxLength)
            return path;

        return $"...{path[^Math.Min(maxLength - 3, path.Length)..]}";
    }
}
