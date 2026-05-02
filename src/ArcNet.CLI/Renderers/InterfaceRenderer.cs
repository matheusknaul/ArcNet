using System.Text;
using ArcNet.CLI.Renderers.Abstractions;
using ArcNet.Core.Interfaces;
using Spectre.Console;

namespace ArcNet.CLI.Renderers;

public class InterfaceRenderer : IRenderer<InterfaceRenderer>
{
    #region Dependencies

    private readonly IUserPreferences _userPreferences;
    public int ScreenWidth { get; set; }
    public int ScreenHeight { get; set; }

    #endregion

    #region Properties

    private readonly List<string> _providers_list = new List<string>
        {
            "Groq - gpt OSS 20B, gpt OSS 120B, others",
            "Local (Ollama) - custom",
            "Custom - set your custom provider/model in 'custom_preferences'"
        };

    #endregion

    #region Layouts

    private Layout _header;
    private Layout _specs;
    private Layout _userPreferencesSet;
    private Layout promptInputing;
    private Layout _promptProcessing;

    #endregion

    public InterfaceRenderer(IUserPreferences userPreferences)
    {
        _userPreferences = userPreferences;
        ScreenWidth = Console.WindowWidth;
        ScreenHeight = Console.WindowHeight;
    }

    public void Run()
    {
        var width = AnsiConsole.Console.Profile.Width;
        var height = AnsiConsole.Console.Profile.Height;
        
        
    }

     public void RenderInput()
    {
        var buffer = new StringBuilder();

        while(true){
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
            {
                break;
            }

            buffer.Append(key);
        }
    }

    public void Render(InterfaceRenderer model)
    {
        throw new NotImplementedException();
    }
}   