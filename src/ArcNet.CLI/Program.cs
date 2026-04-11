using Spectre.Console;
using ArcNet.Core.Entities;
using ArcNet.CLI.Renderers;

AnsiConsole.Markup("[bold purple]⚡ ArcNet iniciado[/]\n");

var input = AnsiConsole.Ask<string>("> ");

var dir = new DirectoryInfo("/home/matheus/Projects/jobs-assistent/");

var dict = new DirectoryNode(dir);

var tree = new DirectoryTreeRenderer();

tree.Render(dict);