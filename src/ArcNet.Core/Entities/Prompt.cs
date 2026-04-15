namespace ArcNet.Core.Entities;

public class Root
{
    public Prompt Planning { get; set; }
    public Prompt Execution { get; set; }
    public Prompt Completion { get; set; }
}

public class Prompt
{
    public string? System { get; set; }
    public string? Instructions { get; set; }
    public string? Context { get; set; }
    public string? Input { get; set; }
    public string? ReforcedInstructions { get; set; }
    public string? OutputFormat { get; set; }
}