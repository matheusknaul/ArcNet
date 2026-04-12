using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;

namespace ArcNet.Infrastructure.Providers;

public class ActionExecutor: IActionExecutor
{
    private readonly IFileAnalyzer _fileAnalyzer;

    public async Task<string> Execute(ActionExecution action)
    {
        return action.Type switch
        {
            "analyze_file" => await _fileAnalyzer.Analyze(action.Target)
        };
    }
}