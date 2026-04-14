using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;

namespace ArcNet.Infrastructure.Providers;

public class ActionExecutor: IActionExecutor
{
    private readonly IDirectoryAnalyzer _directoryAnalyzer;
    private readonly IFileAnalyzer _fileAnalyzer;

    public ActionExecutor(IFileAnalyzer fileAnalyzer, IDirectoryAnalyzer directoryAnalyzer)
    {
        _directoryAnalyzer = directoryAnalyzer;
        _fileAnalyzer
    }

    public async Task<string> Execute(ActionExecution action)
    {
        return action.Type switch
        {
            "analyze_file" => await _fileAnalyzer.Analyze(action.Target),
            "analyze_directory" => await _directoryAnalyzer.Analyze();
        };
    }
}