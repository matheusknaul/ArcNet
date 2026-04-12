namespace ArcNet.Core.Entities;

public class FileSummary
{
    public string File { get; set; }
    public List<string> Methods { get; set; } = new();
    public List<string> Deps { get; set; } = new();
}