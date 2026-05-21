using ArcNet.CLI.Renderers;
using Spectre.Console;

var state = CreateInitialState();
var renderer = new ConsoleAppRenderer();
var running = true;

state.AddSystemMessage("Console iniciado. Digite /help para ver os comandos.");

while (running)
{
    renderer.Render(state);

    var input = AnsiConsole.Prompt(
        new TextPrompt<string>("[bold cyan]>[/]")
            .AllowEmpty());

    if (string.IsNullOrWhiteSpace(input))
        continue;

    if (input.StartsWith('/'))
    {
        running = HandleCommand(input, state);
        continue;
    }

    state.AddUserMessage(input);
    state.Status = ConsoleAgentStatus.Planning;
    state.AddAssistantMessage(
        "Recebi sua solicitacao. A UI ja esta pronta para o ciclo de planejamento; o proximo passo e conectar este fluxo ao AgentOrchestrator.");
    state.Status = ConsoleAgentStatus.Done;
}

AnsiConsole.Clear();
AnsiConsole.MarkupLine("[cyan]ArcNet finalizado.[/]");

static ConsoleAppState CreateInitialState()
{
    var currentDirectory = FindWorkspaceRoot(new DirectoryInfo(Environment.CurrentDirectory));
    var state = new ConsoleAppState
    {
        ProjectName = currentDirectory.Name,
        ProviderName = "Ollama/Groq",
        ModelName = "Selecione com /provider",
        Status = ConsoleAgentStatus.Idle
    };

    foreach (var line in BuildContextLines(currentDirectory))
        state.ContextLines.Add(line);

    state.ActivityLines.Add($"Workspace: {currentDirectory.Name}");
    state.ActivityLines.Add($"{CountFiles(currentDirectory, "*.csproj")} project files found");
    state.ActivityLines.Add($"{CountFiles(currentDirectory, "*.cs")} C# files mapped");

    state.HintLines.Add("/help shows commands");
    state.HintLines.Add("/context refreshes project context");
    state.HintLines.Add("Type a task to start planning");

    return state;
}

static bool HandleCommand(string input, ConsoleAppState state)
{
    var command = input.Trim()[1..].Trim().ToLowerInvariant();

    switch (command)
    {
        case "exit":
        case "quit":
        case "q":
            return false;

        case "clear":
            state.ClearHistory();
            state.Status = ConsoleAgentStatus.Idle;
            state.AddSystemMessage("Historico da tela limpo.");
            return true;

        case "help":
        case "helps":
        case "h":
            state.Status = ConsoleAgentStatus.Idle;
            state.AddSystemMessage(
                "Comandos: /help, /status, /context, /models, /provider, /clear, /exit.");
            return true;

        case "status":
            state.Status = ConsoleAgentStatus.Idle;
            state.AddSystemMessage(
                $"Status: {state.Status}. Projeto: {state.ProjectName}. Provider: {state.ProviderName}. Modelo: {state.ModelName}.");
            return true;

        case "context":
            state.Status = ConsoleAgentStatus.Idle;
            state.AddSystemMessage("Contexto do projeto atualizado no painel lateral.");
            return true;

        case "models":
            state.Status = ConsoleAgentStatus.Idle;
            state.AddSystemMessage(
                "A listagem real de modelos sera conectada ao CommandService. Esta tela ja reserva o fluxo para esse retorno.");
            return true;

        case "provider":
            state.Status = ConsoleAgentStatus.Idle;
            state.AddSystemMessage(
                "O seletor interativo de provider/modelo sera conectado aqui. Por enquanto, a tela mostra o estado atual no header.");
            return true;

        default:
            state.Status = ConsoleAgentStatus.Error;
            state.AddSystemMessage($"Comando desconhecido: /{command}. Use /help.");
            return true;
    }
}

static DirectoryInfo FindWorkspaceRoot(DirectoryInfo start)
{
    var current = start;

    while (current.Parent is not null)
    {
        if (current.EnumerateFiles("*.sln").Any())
            return current;

        current = current.Parent;
    }

    return start;
}

static IEnumerable<string> BuildContextLines(DirectoryInfo root)
{
    yield return $"Raiz: {root.FullName}";
    yield return $"Projetos: {CountFiles(root, "*.csproj")}";
    yield return $"Solutions: {CountFiles(root, "*.sln")}";
    yield return $"Arquivos C#: {CountFiles(root, "*.cs")}";
    yield return $"Testes: {CountFiles(new DirectoryInfo(Path.Combine(root.FullName, "tests")), "*.cs")}";
}

static int CountFiles(DirectoryInfo directory, string pattern)
{
    if (!directory.Exists)
        return 0;

    return directory
        .EnumerateFiles(pattern, SearchOption.AllDirectories)
        .Count(file => IsRelevantPath(file.FullName));
}

static bool IsRelevantPath(string path)
{
    var ignoredSegments = new[]
    {
        $"{Path.DirectorySeparatorChar}.git{Path.DirectorySeparatorChar}",
        $"{Path.DirectorySeparatorChar}.vs{Path.DirectorySeparatorChar}",
        $"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}",
        $"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}",
        $"{Path.DirectorySeparatorChar}node_modules{Path.DirectorySeparatorChar}"
    };

    return !ignoredSegments.Any(path.Contains);
}
