using ArcNet.Core.Entities;

namespace ArcNet.CLI.Handlers
;

public interface ICommandHandler
{
    Task<CommandFormatResponse> Handle(string command);
}