using ArcNet.Core.Interfaces;

namespace ArcNet.Core.Entities;

public class UserPreferences
{
    public string? Model { get; set; }
    public Provider Provider { get; set; } = new();
    public string? ProjectName { get; set; }
    public string? ApiKey { get; set; }
    public int TokenLimits { get; set; } = 1024;
}