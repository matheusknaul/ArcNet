namespace ArcNet.Core.Entities;

public class Provider
{
    public string Name { get; set; }
    public string? BaseUrl { get; set; }
    public List<Model> Models { get; set; } = new();
}

public class Model
{
    public string Name { get; set; }
    public string? Version { get; set; }
    public string? Parameters { get; set; }
    public int ContextWindow { get; set; }
    public bool IsChatModel { get; set; }
    public bool IsLocal { get; set; }
    public string? Endpoint { get; set; }
}