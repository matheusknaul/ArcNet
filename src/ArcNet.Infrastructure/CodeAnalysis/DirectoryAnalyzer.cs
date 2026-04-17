using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;

namespace ArcNet.Infrastructure.CodeAnalysis;

public class DirectoryAnalyzer : IDirectoryAnalyzer
{
    private readonly DirectoryNode _directory;

    public DirectoryAnalyzer(DirectoryNode node)
    {
        _directory = node;
    }

    public Task<string> Analyze()
    {
        throw new NotImplementedException();
    }

    public DirectoryNode GetDirectoryNode()
    {
        throw new NotImplementedException();
    }

    public FileNode GetFileNode(string fileName)
    {
        throw new NotImplementedException();
    }

    public string GetFileName(string fullPath)
    {
        return _directory.GetFileName(fullPath);
    }

    public string GetProjectName()
    {
        return _directory.Name;
    }
}