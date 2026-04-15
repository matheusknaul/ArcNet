namespace ArcNet.Application.Interfaces;

public interface ICommandsExecution
{
    Task<string> Build(string path);
    Task<string> Test(string path);
    Task<string> RunApp(string path);
}