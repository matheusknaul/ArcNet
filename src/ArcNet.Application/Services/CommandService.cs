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

    public Task<CommandFormatResponse> ExecuteHelpCommandAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<CommandFormatResponse> ExecuteModelsCommandAsync()
    {
        var response = new CommandFormatResponse{
            
            ColorTitle = "White",
            Description = "Available models"
        };

        var provider = new Provider();

        if(_userPreferences.Provider.Name.Contains("Ollama"))
            provider = await _ollamaFacade.GetInfoAsync();
        
        response.Title = $"Models - Provider ({provider.Name})";

        foreach(var model in provider.Models)
        {
            response.Lines.Add(new CommandFormatResponseLine
            {
                Content = $"{model.Name} {model.Version} {model.Parameters} - {model.Endpoint}"
            });
        }

        return response;
    }

    public Task<CommandFormatResponse> ExecuteProviderCommandAsync()
    {
        throw new NotImplementedException();
    }

}