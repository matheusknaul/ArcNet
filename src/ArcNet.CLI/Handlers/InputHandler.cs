using ArcNet.Core.Entities;

namespace ArcNet.CLI.Handlers;

public class InputHandler
{
    private readonly ICommandHandler _commandHandler;

    public InputHandler(ICommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public async Task<CommandFormatResponse?> HandleAsync(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null!;

        var command = input.StartsWith("/")
            ? input[1..]
            : input;

        return await _commandHandler.Handle(command);
    }

}
