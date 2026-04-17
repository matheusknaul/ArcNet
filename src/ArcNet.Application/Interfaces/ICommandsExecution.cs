namespace ArcNet.Application.Interfaces;

public interface IProjectCommandsExecution
{
    Task<string> Build(string path);
    Task<string> Test(string path);
    Task<string> RunApp(string path);
    Task<string> AddPackage(string path, string packageName);
    Task<string> AddReference(string path, string referenceName);
    Task<string> AddNewProject(string path, string projectName);
    Task<string> AddNewProjectList(string path);
}