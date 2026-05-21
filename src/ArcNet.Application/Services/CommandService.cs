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
        return Task.FromResult(new CommandFormatResponse
        {
            Title = "Comandos",
            ColorTitle = "cyan",
            Description = "Comandos disponiveis no console do ArcNet.",
            Lines =
            {
                new CommandFormatResponseLine { Content = "/help - mostra os comandos disponiveis" },
                new CommandFormatResponseLine { Content = "/models - lista modelos do provider atual" },
                new CommandFormatResponseLine { Content = "/provider - mostra o provider atual" },
                new CommandFormatResponseLine { Content = "/clear - limpa o historico da tela" },
                new CommandFormatResponseLine { Content = "/exit - encerra o console" }
            }
        });
    }

    public async Task<CommandFormatResponse> ExecuteModelsCommandAsync()
    {
        var response = new CommandFormatResponse{
            
            ColorTitle = "White",
            Description = "Available models"
        };

        var provider = new Provider();

        if(_userPreferences.Provider.Name?.Contains("Ollama") == true)
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
        var provider = _userPreferences.Provider;

        return Task.FromResult(new CommandFormatResponse
        {
            Title = "Provider",
            ColorTitle = "cyan",
            Description = string.IsNullOrWhiteSpace(provider.Name)
                ? "Nenhum provider configurado."
                : $"{provider.Name} ({provider.BaseUrl ?? "sem endpoint configurado"})"
        });
    }

}
