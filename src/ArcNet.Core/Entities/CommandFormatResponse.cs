namespace ArcNet.Core.Entities;

public class CommandFormatResponse
{
    public string? Title { get; set; }
    public string? ColorTitle { get; set; }
    public string? Description { get; set; }
    public string? ColorDescription { get; set; }
    public List<CommandFormatResponseLine> Lines { get; set; } = new();
}

public class CommandFormatResponseLine
{
    public string? Content { get; set; }
    public string? ContentColor { get; set; }
}
