using ArcNet.Application.Interfaces;
using Spectre.Console;

namespace ArcNet.CLI.Renderers.Components;

public class ScreenBuffer : IBuffer
{
    private List<Layout> _layoutsActives = new();
    public string? InputBuffer { get; set; }
    private Queue<string> _contentToRender = new();

    public void ClearInput()
    {
        Console.Clear();
        Console.Write(InputBuffer);
    } 

    public void UpdateInputBuffer(string input)
    {
        InputBuffer = input;
    }

    public void BufferContent(IEnumerable<string> content)
    {
        foreach (var item in content)
            _contentToRender.Enqueue(item);
    }

    public IEnumerable<string> UseBufferContent()
    {
        while (_contentToRender.Count > 0)
            yield return _contentToRender.Dequeue();
    }
}