namespace ArcNet.Application.Interfaces;

public interface ICommandService
{
    Task<List<string>> ExecuteHelpCommandAsync();
    Task<List<string>> ExecuteModelsCommandAsync();
    Task<List<string>> ExecuteProviderCommandAsync();
}