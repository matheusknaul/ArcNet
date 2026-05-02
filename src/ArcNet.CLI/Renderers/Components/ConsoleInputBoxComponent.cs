using System.ComponentModel;
using System.Text;
using ArcNet.CLI.Renderers.Abstractions;
using Spectre.Console;

namespace ArcNet.CLI.Renderers.Components;

public class ConsoleInputBoxComponent : IRendererComponent
{
    #region Properties

    private readonly StringBuilder _buffer = new();
    private int _inputXPosition => _buffer.Length + 2;
    private int _inputBaseX = 2;
    private int _inputYPosition = 0;

    #endregion

    #region DI

    private readonly ScreenBuffer _screenBuffer;

    #endregion

    public ConsoleInputBoxComponent(ScreenBuffer screenBuffer)
    {
        _screenBuffer = screenBuffer;
    }

    public string Read()
    {
        AnsiConsole.MarkupLine("[grey]Dica: use /help para comandos[/]");

        AnsiConsole.Write(new Rule());

        var input = AnsiConsole.Prompt(
            new TextPrompt<string>(">")
        );

        AnsiConsole.Write(new Rule());

        _screenBuffer.UpdateInputBuffer(input);
        return input;
    }

    private void HandleKey(ConsoleKeyInfo key)
    {
        if (key.Key == ConsoleKey.Backspace)
        {
            if (_buffer.Length > 0)
                _buffer.Remove(_buffer.Length - 1, 1);
        }
        else if (!char.IsControl(key.KeyChar))
        {
            _buffer.Append(key.KeyChar);
        }
            _screenBuffer.UpdateInputBuffer(_buffer.ToString());   
    }

    private void Draw()
    {
        Console.SetCursorPosition(_inputBaseX, _inputYPosition);
        Console.Write(new string(' ', Console.WindowWidth));

        Console.SetCursorPosition(_inputBaseX, _inputYPosition);
        AnsiConsole.Prompt(new TextPrompt<string>(">"));

        Console.SetCursorPosition(_inputBaseX + 2 + _buffer.Length, _inputYPosition);
    }

    private void Initialize()
    {
        var (left, top) = Console.GetCursorPosition();
        _inputYPosition = top;

        Console.SetCursorPosition(_inputBaseX, _inputYPosition);
        Console.Write(new string(' ', Console.WindowWidth));

        Console.SetCursorPosition(_inputBaseX, _inputYPosition);
        AnsiConsole.Prompt(new TextPrompt<string>(">"));
    }
}