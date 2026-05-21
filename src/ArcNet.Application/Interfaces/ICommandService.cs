using ArcNet.Core.Entities;

namespace ArcNet.Application.Interfaces;

public interface ICommandService
{
    Task<CommandFormatResponse> ExecuteHelpCommandAsync();
    Task<CommandFormatResponse> ExecuteModelsCommandAsync();
    Task<CommandFormatResponse> ExecuteProviderCommandAsync();
}