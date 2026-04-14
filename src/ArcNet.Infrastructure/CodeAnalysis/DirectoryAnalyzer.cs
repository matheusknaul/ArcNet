using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;

namespace ArcNet.Infrastructure.CodeAnalysis;

public class DirectoryAnalyzer : IDirectoryAnalyzer
{
    private readonly DirectoryNode _directory;

    public DirectoryAnalyzer()
    {
        
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
}