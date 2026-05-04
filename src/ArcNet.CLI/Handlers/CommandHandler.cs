using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;

namespace ArcNet.CLI.Handlers;

public class CommandHandler : ICommandHandler
{
    private string Help { get; set; } = "help";
    private string Models { get; set; } = "models";
    private string Provider { get; set; } = "provider";

    #region DI 
    private readonly ICommandService _commandsService;
    private readonly IBuffer _buffer;
    #endregion

    public CommandHandler(ICommandService commandsService, IBuffer buffer)
    {
        _commandsService = commandsService;
        _buffer = buffer;
    }

    public async Task<CommandFormatResponse> Handle(string command)
    {
        if(command.Contains("help"))
            return await HandleHelp();
        
        if(command.Contains("models"))
            return await HandleModels();
        
        if(command.Contains("provider"))
            return await HandleProvider();
        
        return null!;
    }

    private async Task<CommandFormatResponse> HandleHelp()
    {
        return await _commandsService.ExecuteHelpCommandAsync();
    }

    private async Task<CommandFormatResponse> HandleModels()
    {
        return await _commandsService.ExecuteModelsCommandAsync();
    }

    private async Task<CommandFormatResponse> HandleProvider()
    {
        return await _commandsService.ExecuteProviderCommandAsync();
    }
}