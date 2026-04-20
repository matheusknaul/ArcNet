using ArcNet.Application.Interfaces;

namespace ArcNet.Infrastructure.Execution;

public class FileCommandsExecution : IFileCommandsExecution
{
    private readonly ICheckpointManager _checkPointManager;

    public FileCommandsExecution(ICheckpointManager checkpoint)
    {
        _checkPointManager = checkpoint;
    }

    public Task<string> CreateFile(string path, string name, string content)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteFile(string path, string name)
    {
        throw new NotImplementedException();
    }
}       