using System.Diagnostics;
using ArcNet.Application.Interfaces;

namespace ArcNet.Infrastructure.Execution;

public class ProjectCommandsExecution : IProjectCommandsExecution
{
    private readonly ICheckpointManager _checkPointManager;

    public ProjectCommandsExecution(ICheckpointManager checkpoint)
    {
        _checkPointManager = checkpoint;
    }

    public async Task<string> Build(string path)
    {
        return await Run("dotnet", "build", path);
    }

    public async Task<string> AddPackage(string path, string packageName)
    {
        return await Run("dotnet", $"add package {packageName}", path);
    }

    public async Task<string> AddReference(string path, string referenceName)
    {
        return await Run("dotnet", $"add reference {referenceName}", path);
    }

    public async Task<string> AddNewProject(string path, string projectNameName)
    {
        return await Run("dotnet", $"new package {projectNameName}", path);
    }

    public async Task<string> AddNewProjectList(string path)
    {
        return await Run("dotnet", $"new list", path);
    }

    public async Task<string> Test(string path)
    {
        return await Run("dotnet", "test", path);
    }

    public async Task<string> RunApp(string path)
    {
        return await Run("dotnet", "run", path);
    }

    private async Task<string> Run(string command, string args, string workingDir)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = args,
                WorkingDirectory = workingDir,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            }
        };

        process.Start();

        var output = await process.StandardOutput.ReadToEndAsync();
        var error = await process.StandardError.ReadToEndAsync();

        process.WaitForExit();

        return output + error;
    }
}