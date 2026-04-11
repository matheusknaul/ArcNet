using Spectre.Console;

AnsiConsole.Markup("[bold purple]⚡ ArcNet iniciado[/]\n");

var input = AnsiConsole.Ask<string>("> ");

AnsiConsole.Markup($"Você digitou: [yellow]{input}[/]\n");