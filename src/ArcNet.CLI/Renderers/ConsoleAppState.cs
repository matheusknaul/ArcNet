namespace ArcNet.CLI.Renderers;

public sealed class ConsoleAppState
{
    private const int MaxHistoryItems = 14;

    public string ProjectName { get; set; } = "ArcNet";
    public string ProviderName { get; set; } = "Nao configurado";
    public string ModelName { get; set; } = "Nao selecionado";
    public ConsoleAgentStatus Status { get; set; } = ConsoleAgentStatus.Idle;
    public List<ConsoleTimelineItem> History { get; } = new();
    public List<string> ContextLines { get; } = new();
    public List<string> ActivityLines { get; } = new();
    public List<string> HintLines { get; } = new();

    public bool HasConversation => History.Count > 1 || History.Any(item => item.Role is "Voce" or "ArcNet");

    public void AddUserMessage(string content)
    {
        Add("Voce", content);
    }

    public void AddAssistantMessage(string content)
    {
        Add("ArcNet", content);
    }

    public void AddSystemMessage(string content)
    {
        Add("Sistema", content);
    }

    public void ClearHistory()
    {
        History.Clear();
    }

    private void Add(string role, string content)
    {
        History.Add(new ConsoleTimelineItem(role, content));

        if (History.Count > MaxHistoryItems)
            History.RemoveRange(0, History.Count - MaxHistoryItems);
    }
}
