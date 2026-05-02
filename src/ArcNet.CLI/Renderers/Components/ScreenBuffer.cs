using Spectre.Console;

namespace ArcNet.CLI.Renderers.Components;

public class ScreenBuffer()
{
    private List<Layout> _layoutsActives = new();
    public string InputBuffer { get; set; }

    public void ClearInput()
    {
        Console.Clear();
        Console.Write(InputBuffer);
    } 

    private void WriteInputBuffer()
    {
        
    }

    public void UpdateInputBuffer(string input)
    {
        InputBuffer = input;
    }
}