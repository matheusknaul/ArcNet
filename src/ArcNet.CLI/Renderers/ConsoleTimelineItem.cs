namespace ArcNet.CLI.Renderers;

public sealed class ConsoleTimelineItem
{
    public string Role { get; }
    public string Content { get; }
    public DateTime CreatedAt { get; }

    public ConsoleTimelineItem(string role, string content)
    {
        Role = role;
        Content = content;
        CreatedAt = DateTime.Now;
    }
}
