using System.Text.Json;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArcNet.CLI.Handlers;

public class InputHandler
{
    private readonly ICommandHandler _commandHandler;

    public InputHandler(ICommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public async Task<string> HandleAsync(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null!;

        var command = input.StartsWith("/")
            ? input[1..]
            : input;

        var commandResponse = await _commandHandler.Handle(command);

        var json = JsonSerializer.Serialize(commandResponse);

        return json;
    }

}