using ArcNet.Core.Interfaces;

namespace ArcNet.Core.Entities;

public class UserPreferences : IUserPreferences
{
    public string Model { get; set; }
    public string Provider { get; set; }
    public string ProjectName { get; set; }
    public string? ApiKey { get; set; }
    public int TokenLimits { get; set; } = 1024;

    public UserPreferences GetUserPreferences()
    {
        return this;
    }
}