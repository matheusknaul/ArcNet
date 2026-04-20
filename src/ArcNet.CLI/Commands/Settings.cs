using System.ComponentModel;
using Spectre.Console.Cli;

namespace ArcNet.CLI.Commands;

public class Settings : CommandSettings
{
    [CommandOption("--port [PORT]")]
    [Description("The port to listen on (default: 3000 if flag present)")]
    [DefaultValue(3000)]
    public required FlagValue<int> Port { get; init; }
  
    [CommandOption("--timeout [SECONDS]")]
    [Description("Connection timeout in seconds")]
    public required FlagValue<int?> Timeout { get; init; }
  
    [CommandOption("-h|--host")]
    [Description("The host to bind to")]
    [DefaultValue("localhost")]
    public required string Host { get; init; } = "localhost";
}