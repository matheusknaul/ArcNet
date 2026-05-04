using System.Text;
using Spectre.Console;
using ArcNet.CLI.Renderers.Components;

var buffer = new StringBuilder();
var running = true;
var inputing = true;
var timeStack = 20;
var needClear = true;
var showed = false;

var sb = new ScreenBuffer();

var cib = new ConsoleInputBoxComponent(sb);

var features = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
    .Title("Escolha o seu [blue]provider[/]:")
    .AddChoices("Groq - gpt OSS 20B, gpt OSS 120B, others", "Ollama (Local) - Search for models", "Custom - set your custom provider/model in 'custom_preferences'"));

AnsiConsole.Status()
    .Spinner(Spinner.Known.Arc)
    .SpinnerStyle(Style.Parse("blue"))
    .Start("Analisando modelos do [blue]Ollama[/]", ctx =>
    {
        Thread.Sleep(3000);
  
        AnsiConsole.MarkupLine("Encontrados [blue]5[/] modelos no total!");
    });

AnsiConsole.Status()
    .Spinner(Spinner.Known.Arc)
    .SpinnerStyle(Style.Parse("blue"))
    .Start("Analisando diretório...", ctx =>
    {
        Thread.Sleep(3000);
  
        AnsiConsole.MarkupLine("Encontrado [blue]4[/] projetos e [blue]52[/] arquivos!");
    });

var chart = new BreakdownChart()
    //.ShowPercentage()
    .UseValueFormatter((value, culture) => $"{value:N0}k tokens")
    .Width(100)
    .AddItem("Consumido", 73, Color.DarkGoldenrod)
    .AddItem("Livre", 18, Color.DarkOliveGreen3)
    .AddItem("Reservado", 9, Color.Gray);
  
AnsiConsole.Write(chart);

Thread.Sleep(30000);

while (running)
{
    if(needClear)
    {
        Console.Clear();
        needClear = false;
    }
    
    if(inputing)
        cib.Read();

    inputing = false;

    if (!showed)
    {
        Console.WriteLine(sb.InputBuffer);
        showed = true;
    }
    
}

