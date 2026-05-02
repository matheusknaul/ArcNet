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

