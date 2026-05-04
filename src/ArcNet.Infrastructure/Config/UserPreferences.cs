using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;
using ArcNet.Core.Interfaces;

namespace ArcNet.Infrastructure.Config;

public class UserPreferencesConfig : IUserPreferences
{
    private readonly IOllamaFacade _ollamaFacade;
    private UserPreferences _userPreferences = new();

    public UserPreferencesConfig(IOllamaFacade ollamaFacade)
    {
        _ollamaFacade = ollamaFacade;
    }

    public UserPreferences GetUserPreferences()
    {
        return _userPreferences;
    }

    public async Task SetPreferences(UserPreferences preferences)
    {
        _userPreferences = preferences;
        await SetOllamaProviderConfig();
    }

    private async Task SetOllamaProviderConfig()
    {
        var endpoint = Environment.GetEnvironmentVariable("OLLAMA_HOST")
               ?? "localhost:11434";

        _userPreferences.Provider = await _ollamaFacade.GetInfoAsync();
        _userPreferences.Provider.BaseUrl = endpoint;
    }
}