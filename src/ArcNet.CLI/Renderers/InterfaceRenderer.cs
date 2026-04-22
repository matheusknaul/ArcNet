using ArcNet.CLI.Renderers.Abstractions;
using ArcNet.Core.Interfaces;
using Spectre.Console;

namespace ArcNet.CLI.Renderers;

public class InterfaceRenderer : IRenderer<InterfaceRenderer>
{
    #region Dependencies

    private readonly IUserPreferences _userPreferences;

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
    }

    public void Initialize()
    {
        
    }

     

    public void Render(InterfaceRenderer model)
    {
        throw new NotImplementedException();
    }
}   