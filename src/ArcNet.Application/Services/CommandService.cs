using ArcNet.Core.Entities;
using ArcNet.Core.Interfaces;

namespace ArcNet.Application.Interfaces;

public class CommandService : ICommandService
{
    #region DI
    private readonly UserPreferences _userPreferences;
    private readonly IGroqFacade _groqFacade;
    private readonly IOllamaFacade _ollamaFacade;
    #endregion

    public CommandService(IUserPreferences userPreferences,
        IGroqFacade groqFacade, IOllamaFacade ollamaFacade)
    {
        _userPreferences = userPreferences.GetUserPreferences();
        _groqFacade = groqFacade;
        _ollamaFacade = ollamaFacade;
    }

    public Task<List<string>> ExecuteHelpCommandAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<string>> ExecuteModelsCommandAsync()
    {
        var provider = new Provider();

        if(_userPreferences.Provider.Name.Contains("Ollama"))
            provider = await _ollamaFacade.GetInfoAsync();

        return provider.Models.Select(m => m.Name).ToList();
    }

    public Task<List<string>> ExecuteProviderCommandAsync()
    {
        throw new NotImplementedException();
    }

}