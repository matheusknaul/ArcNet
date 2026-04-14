using ArcNet.Core.Interfaces;

namespace ArcNet.Core.Entities;

public class UserPreferences : IUserPreferences
{
    public string Model { get; set; }

    public UserPreferences GetUserPreferences()
    {
        return this;
    }
}