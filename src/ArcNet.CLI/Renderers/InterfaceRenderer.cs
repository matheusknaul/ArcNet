using Spectre.Console;
using Spectre.Console.Rendering;

namespace ArcNet.CLI.Renderers;

public class InterfaceRenderer
{
    #region Dependencies

    private readonly List<string> _providers_list = new List<string>
        {"Groq - gpt OSS 20B, gpt OSS 120B, Outros","Local (Ollama) - Personalizado"};

    #endregion

    #region Layouts

    private Layout _header;
    private Layout _specs;
    private Layout _userPreferencesSet;
    private Layout _userPrompt;
    private Layout _modelProcessing;

    #endregion

    public InterfaceRenderer(){}


}