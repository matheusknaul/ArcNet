using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;

namespace ArcNet.Infrastructure.Providers;

public class ActionExecutor: IActionExecutor
{
    private readonly IDirectoryAnalyzer _directoryAnalyzer;
    private readonly IFileAnalyzer _fileAnalyzer;
    private readonly IProjectCommandsExecution _projectCommandsExecution;
    private readonly IFileCommandsExecution _fileCommandsExecution;

    public ActionExecutor(IFileAnalyzer fileAnalyzer, IDirectoryAnalyzer directoryAnalyzer,
        IProjectCommandsExecution projectCommandsExecution, IFileCommandsExecution fileCommandsExecution)
    {
        _directoryAnalyzer = directoryAnalyzer;
        _fileAnalyzer = fileAnalyzer;
        _projectCommandsExecution = projectCommandsExecution;
        _fileCommandsExecution = fileCommandsExecution;
    }

    public async Task<string> Execute(ActionExecution action)
    {
        return action.Type switch
        {
            "analyze_file" => await _fileAnalyzer.Analyze(action.Instructions.TargetName),
            "analyze_directory" => await _directoryAnalyzer.Analyze(),
            "create_file" => await _fileCommandsExecution.CreateFile(action.Instructions.PathToExecute, action.Instructions.TargetName, action.Instructions.ContentCreator!),
            "delete_file" => await _fileCommandsExecution.DeleteFile(action.Instructions.PathToExecute, action.Instructions.TargetName),
            "run_app" => await _projectCommandsExecution.RunApp(action.Instructions.PathToExecute),
            "create_project" => await _projectCommandsExecution.AddNewProject(action.Instructions.PathToExecute, action.Instructions.TargetName),
            "add_reference" => await _projectCommandsExecution.AddReference(action.Instructions.PathToExecute, action.Instructions.TargetName),
            "add_package" => await _projectCommandsExecution.AddPackage(action.Instructions.PathToExecute, action.Instructions.TargetName),
            "verify_dotnet_new_options" => await _projectCommandsExecution.AddNewProjectList(action.Instructions.PathToExecute)
        };
    }
}