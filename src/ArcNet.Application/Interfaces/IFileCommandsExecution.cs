namespace ArcNet.Application.Interfaces;

public interface IFileCommandsExecution
{
    Task<string> CreateFile(string path, string name, string content);
    Task<string> DeleteFile(string path, string name);
}